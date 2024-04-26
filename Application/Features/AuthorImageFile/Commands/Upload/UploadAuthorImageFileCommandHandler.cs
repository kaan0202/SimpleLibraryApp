using Application.Abstraction.Storage;
using Application.Repositories.Author;
using Application.Repositories.AuthorImageFile;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AuthorImageFile.Commands.Upload
{
    public class UploadAuthorImageFileCommandHandler : IRequestHandler<UploadAuthorImageFileCommandRequest, BaseResponse>
    {
        readonly IAuthorImageFileReadRepository _authorImageFileReadRepository;
        readonly IAuthorImageFileWriteRepository _authorImageFileWriteRepository;
        readonly IStorageService _storageService;
        readonly IAuthorReadRepository _authorReadRepository;
       

        public UploadAuthorImageFileCommandHandler(IAuthorImageFileReadRepository authorImageFileReadRepository, IAuthorImageFileWriteRepository authorImageFileWriteRepository, IStorageService storageService, IAuthorReadRepository authorReadRepository)
        {
            _authorImageFileReadRepository = authorImageFileReadRepository;
            _authorImageFileWriteRepository = authorImageFileWriteRepository;
            _storageService = storageService;
            _authorReadRepository = authorReadRepository;
            
        }

        public async Task<BaseResponse> Handle(UploadAuthorImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> datas = await _storageService.UploadAsync("author-images", request.Files);
            var author = _authorReadRepository.GetByIdAsync(request.Id);
            await _authorImageFileWriteRepository.AddRangeAsync(datas.Select(x => new Domain.Entities.File.AuthorImageFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Storage = _storageService.StorageName,
                AuthorId = author.Id
            }).ToList());

            return new SuccessWithNoDataResponse("Resim Eklendi");
        }
    }
}
