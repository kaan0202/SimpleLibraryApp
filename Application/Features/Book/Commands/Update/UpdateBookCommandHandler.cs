using Application.Repositories.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Commands.Update
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>
    {
        readonly IBookReadRepository _bookReadRepository;
        readonly IBookWriteRepository _bookWriteRepository;
        public UpdateBookCommandHandler(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository)
        {
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
        }
        async Task<UpdateBookCommandResponse> IRequestHandler<UpdateBookCommandRequest, UpdateBookCommandResponse>.Handle(UpdateBookCommandRequest request, CancellationToken cancellationToken)
        {
            bool result =  await _bookReadRepository.AnyAsync(data => data.Id == request.Book.Id,false);

            if (result)
            {
                _bookWriteRepository.Update(request.Book);
                return new();
            }
            throw new Exception("Hata");
        }
    }
}
