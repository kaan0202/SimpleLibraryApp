using Application.Abstraction.Storage;
using Application.Repositories.Book;
using Application.Repositories.BookImageFile;
using Application.UnitOfWork;
using Domain.Entities;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookImageFile.Commands.Upload
{
    public class UploadBookImageFileCommandHandler : IRequestHandler<UploadBookImageFileCommandRequest, BaseResponse>
    {
        readonly IBookImageFileReadRepository _bookImageFileReadRepository;
        readonly IBookImageFileWriteRepository _bookImageFileWriteRepository;
        readonly IStorageService _storageService;
        readonly IBookReadRepository _bookReadRepository;
        readonly IUnitOfWork _unitOfWork;

        public UploadBookImageFileCommandHandler(IBookImageFileReadRepository bookImageFileReadRepository, IBookImageFileWriteRepository bookImageFileWriteRepository, IStorageService storageService, IBookReadRepository bookReadRepository, IUnitOfWork unitOfWork)
        {
            _bookImageFileReadRepository = bookImageFileReadRepository;
            _bookImageFileWriteRepository = bookImageFileWriteRepository;
            _storageService = storageService;
            _bookReadRepository = bookReadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(UploadBookImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> datas = await _storageService.UploadAsync("book-images", request.Files);
            var book = await _bookReadRepository.GetByIdAsync(request.Id);
            await _bookImageFileWriteRepository.AddRangeAsync(datas.Select(x => new Domain.Entities.File.BookImageFile
            {
                FileName = x.fileName,
                Path = x.pathOrContainerName,
                Storage = _storageService.StorageName,
                BookId = book.Id
            }).ToList());
            await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Resim Eklendi");
        }
    }
}
