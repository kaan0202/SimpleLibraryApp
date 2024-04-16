using Application.Abstraction.Storage;
using Application.Repositories.Author;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthorImageFile.Queries.GetAuthorImages
{
    public class GetAuthorImageFileHandler : IRequestHandler<GetAuthorImageFileRequest, BaseDataResponse<List<Domain.Entities.File.AuthorImageFile>>>
    {
        readonly IAuthorReadRepository _repository;
        readonly IStorageService _storageService;

        public GetAuthorImageFileHandler(IAuthorReadRepository repository,IStorageService storageService)
        {
            _repository = repository;
            _storageService = storageService;
        }

        public async Task<BaseDataResponse<List<Domain.Entities.File.AuthorImageFile>>> Handle(GetAuthorImageFileRequest request, CancellationToken cancellationToken)
        {
            var author = await _repository.Table.Include(x =>x.Images).FirstOrDefaultAsync(x =>x.Id == request.Id);
            List <Domain.Entities.File.AuthorImageFile> authorImages = author.Images.Select(r => new Domain.Entities.File.AuthorImageFile
            {
                FileName = r.FileName,
                Path = r.Path,
                Storage = _storageService.StorageName,
                AuthorId = author.Id,
                

            }).ToList();

            return new SuccessDataResponse<List<Domain.Entities.File.AuthorImageFile>>(authorImages);
        }
    }
}
