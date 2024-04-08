using Application.Repositories.Person;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Commands.Add
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommandRequest, BaseResponse>
    {
        readonly IPersonWriteRepository _personWriteRepository;
        public AddPersonCommandHandler(IPersonWriteRepository personWriteRepository)
        {
            _personWriteRepository = personWriteRepository;
        }
       public async Task<BaseResponse> Handle(AddPersonCommandRequest request, CancellationToken cancellationToken)
        {
            await _personWriteRepository.AddAsync(request.Person);
            return new SuccessWithNoDataResponse("Kullanıcı eklendi");
        }
    }
}
