using Application.Repositories.Person;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Commands.Update
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommandRequest, BaseResponse>
    {
        readonly IPersonReadRepository _personReadRepository;
        readonly IPersonWriteRepository _personWriteRepository;
        public UpdatePersonCommandHandler(IPersonReadRepository personReadRepository, IPersonWriteRepository personWriteRepository)
        {
            _personReadRepository = personReadRepository;
            _personWriteRepository = personWriteRepository;
        }
       public async Task<BaseResponse> Handle(UpdatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _personReadRepository.AnyAsync(data => data.Id == request.Person.Id, false);
            if (result)
            {
                _personWriteRepository.Update(request.Person);
                return new SuccessWithNoDataResponse("Kullanıcı Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
