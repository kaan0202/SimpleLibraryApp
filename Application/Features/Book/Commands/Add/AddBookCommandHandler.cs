using Application.Repositories.Book;
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
        public async Task<BaseResponse> Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
        {

            await _bookWriteRepository.AddAsync(request.Book);
            return new SuccessWithNoDataResponse("Kitap Eklendi");
        }
    }
}
