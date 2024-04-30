using Application.Abstraction.Storage;
using Application.Exceptions;
using Application.Repositories.Book;
using Application.Repositories.BookImageFile;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookImageFile.Queries.GetBookImages
{
    public class GetBookImageFileHandler : IRequestHandler<GetBookImageFileRequest, BaseDataResponse<List<Domain.Entities.File.BookImageFile>>>
    {
        readonly IBookReadRepository _bookReadRepository;
        readonly IStorageService _storageService;
        readonly IConfiguration _configuration;

        public GetBookImageFileHandler(IBookReadRepository bookReadRepository, IStorageService storageService, IConfiguration configuration)
        {
            _bookReadRepository = bookReadRepository;
            _storageService = storageService;
            _configuration = configuration;
        }

        public async Task<BaseDataResponse<List<Domain.Entities.File.BookImageFile>>> Handle(GetBookImageFileRequest request, CancellationToken cancellationToken)
        {
           var book = await _bookReadRepository.Table.Include(x=>x.Images).FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (book != null)
            {
                List<Domain.Entities.File.BookImageFile> imageFiles = book.Images.Select(datas => new Domain.Entities.File.BookImageFile
                {
                    FileName = datas.FileName,
                    Path = $"{_configuration["Storage:Local"]}/{datas.Path}",
                    Storage = _storageService.StorageName,
                    BookId = book.Id,
                }).ToList();

                return new SuccessDataResponse<List<Domain.Entities.File.BookImageFile>>(imageFiles);
            }
            throw new NotFoundException("Dosyalar bulunamadı");
        }
    }
}
