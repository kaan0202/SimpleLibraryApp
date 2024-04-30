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
            await _personWriteRepository.AddAsync(request.Person);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Kullanıcı eklendi");
        }
    }
}
