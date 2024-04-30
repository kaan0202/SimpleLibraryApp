using Application.Repositories.Book;
using Application.UnitOfWork;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Commands.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, BaseResponse>
    {
        readonly IBookReadRepository _bookReadRepository;
        readonly IBookWriteRepository _bookWriteRepository;
        readonly IUnitOfWork _unitOfWork;
        public UpdateBookCommandHandler(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository, IUnitOfWork unitOfWork)
        {
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            bool result =  await _bookReadRepository.AnyAsync(data => data.Id == request.Id,false);

            if (result)
            {
                Domain.Entities.Book book = new()
                {
                    AuthorId = request.AuthorId,
                    LanguageId = request.LanguageId,
                    Name = request.Name,
                    PageOfNumber = request.PageOfNumber,
                    CatalogId = request.CatalogId,
                    

                };
                _bookWriteRepository.Update(book);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Kitap Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
