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

namespace Application.Features.Book.Commands.Add
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommandRequest, BaseResponse>
    {
        readonly IBookWriteRepository _bookWriteRepository;
        readonly IUnitOfWork _unitOfWork;

        public AddBookCommandHandler(IBookWriteRepository bookWriteRepository, IUnitOfWork unitOfWork)
        {
            _bookWriteRepository = bookWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Book book = new()
            {
                AuthorId = request.BookDto.AuthorId,
                CatalogId = request.BookDto.CatalogId,
                LanguageId = request.BookDto.LanguageId,
                Name = request.BookDto.Name,
                PageOfNumber = request.BookDto.PageOfNumber,
                
            };

            await _bookWriteRepository.AddAsync(book);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Kitap Eklendi");
        }
    }
}
