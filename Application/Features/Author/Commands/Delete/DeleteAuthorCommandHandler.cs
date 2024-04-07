using Application.Repositories.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Commands.Delete
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, DeleteAuthorCommandResponse>
    {

        readonly IAuthorWriteRepository _authorWriteRepository;
        readonly IAuthorReadRepository _authorReadRepository;

        public DeleteAuthorCommandHandler(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
        }
        async Task<DeleteAuthorCommandResponse> IRequestHandler<DeleteAuthorCommandRequest, DeleteAuthorCommandResponse>.Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _authorReadRepository.AnyAsync(data => data.Id == request.Id,false);  
            if (result == true)
            {
                await _authorWriteRepository.RemoveByIdAsync(request.Id);
                return new();
            }
            throw new Exception("Hata");
        }
    }
}
