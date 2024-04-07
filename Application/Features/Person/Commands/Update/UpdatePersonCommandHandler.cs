using Application.Repositories.Person;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Commands.Update
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommandRequest, UpdatePersonCommandResponse>
    {
        readonly IPersonReadRepository _personReadRepository;
        readonly IPersonWriteRepository _personWriteRepository;
        public UpdatePersonCommandHandler(IPersonReadRepository personReadRepository, IPersonWriteRepository personWriteRepository)
        {
            _personReadRepository = personReadRepository;
            _personWriteRepository = personWriteRepository;
        }
        async Task<UpdatePersonCommandResponse> IRequestHandler<UpdatePersonCommandRequest, UpdatePersonCommandResponse>.Handle(UpdatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _personReadRepository.AnyAsync(data => data.Id == request.Person.Id, false);
            if (result)
            {
                _personWriteRepository.Update(request.Person);
                return new();
            }
            throw new Exception("Hata");
        }
    }
}
