using Application.Repositories.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Commands.Add
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommandRequest, AddPersonCommandResponse>
    {
        readonly IPersonWriteRepository _personWriteRepository;
        public AddPersonCommandHandler(IPersonWriteRepository personWriteRepository)
        {
            _personWriteRepository = personWriteRepository;
        }
        async Task<AddPersonCommandResponse> IRequestHandler<AddPersonCommandRequest, AddPersonCommandResponse>.Handle(AddPersonCommandRequest request, CancellationToken cancellationToken)
        {
            await _personWriteRepository.AddAsync(request.Person);
            return new();
        }
    }
}
