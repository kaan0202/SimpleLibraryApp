using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Commands.Add
{
    public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommandRequest, AddAuthorCommandResponse>
    {
        Task<AddAuthorCommandResponse> IRequestHandler<AddAuthorCommandRequest, AddAuthorCommandResponse>.Handle(AddAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
