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

namespace Application.Features.Person.Commands.Add
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommandRequest, BaseResponse>
    {
        readonly IPersonWriteRepository _personWriteRepository;
        readonly IUnitOfWork _unitOfWork;
        public AddPersonCommandHandler(IPersonWriteRepository personWriteRepository, IUnitOfWork unitOfWork)
        {
            _personWriteRepository = personWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(AddPersonCommandRequest request, CancellationToken cancellationToken)
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
            await _personWriteRepository.AddAsync(person);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Kullanıcı eklendi");
        }
    }
}
