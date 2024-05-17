using Application.Repositories.Person;
using Application.UnitOfWork;
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
        readonly IUnitOfWork _unitOfWork;
        public UpdatePersonCommandHandler(IPersonReadRepository personReadRepository, IPersonWriteRepository personWriteRepository, IUnitOfWork unitOfWork)
        {
            _personReadRepository = personReadRepository;
            _personWriteRepository = personWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(UpdatePersonCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _personReadRepository.AnyAsync(data => data.Id == request.PersonDto.Id, false);
            if (result)
            {
                Domain.Entities.Person person = new()
                {
                    Name = request.PersonDto.Name,
                    AddressId = request.PersonDto.AddressId,
                    BirthDay = request.PersonDto.BirthDay,
                    Email = request.PersonDto.Email,
                    Password = request.PersonDto.Password,
                    Surname = request.PersonDto.Surname,


                };
                _personWriteRepository.Update(person);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Kullanıcı Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
