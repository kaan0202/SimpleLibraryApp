using Application.Repositories.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Commands.Add
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommandRequest, AddBookCommandResponse>
    {
        readonly IBookWriteRepository _bookWriteRepository;
        async Task<AddBookCommandResponse> IRequestHandler<AddBookCommandRequest, AddBookCommandResponse>.Handle(AddBookCommandRequest request, CancellationToken cancellationToken)
        {

            await _bookWriteRepository.AddAsync(request.Book);
            return new();
        }
    }
}
