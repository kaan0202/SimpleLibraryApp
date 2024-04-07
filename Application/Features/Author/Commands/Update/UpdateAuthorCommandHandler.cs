using Application.Repositories.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Commands.Update
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, UpdateAuthorCommandResponse>
    { 
        readonly IAuthorWriteRepository _authorWriteRepository;
        readonly IAuthorReadRepository _authorReadRepository;

        public UpdateAuthorCommandHandler(IAuthorReadRepository authorReadRepository,IAuthorWriteRepository authorWriteRepository)
        {
            _authorReadRepository = authorReadRepository;
            _authorWriteRepository = authorWriteRepository;
        }

        async Task<UpdateAuthorCommandResponse> IRequestHandler<UpdateAuthorCommandRequest, UpdateAuthorCommandResponse>.Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _authorReadRepository.AnyAsync(data => data.Id == request.Author.Id,false);
            if (result==true)
            {
                 _authorWriteRepository.Update(request.Author);
                return new();
            }
            throw new Exception("Hata");
        }
    }
}
