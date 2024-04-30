using Application.Repositories.Book;
using Application.UnitOfWork;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BookImageFile.Commands.Remove
{
    public class RemoveBookImageFileCommandHandler : IRequestHandler<RemoveBookImageFileCommandRequest, BaseResponse>
    {
        readonly IBookReadRepository _bookReadRepository;
        readonly IBookWriteRepository _bookWriteRepository;
        readonly IUnitOfWork _unitOfWork;

        public RemoveBookImageFileCommandHandler(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IUnitOfWork unitOfWork)
        {
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(RemoveBookImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookReadRepository.Table.Include(x =>x.Images).FirstOrDefaultAsync(x=>x.Id == request.Id);
            Domain.Entities.File.BookImageFile images =   book.Images.FirstOrDefault(x =>x.Id == request.ImageId);
            if(images != null)
            {
                book.Images.Remove(images);
                await _unitOfWork.SaveChangesAsync();
            }
            throw new Exception("Hata");
        }
    }
}
