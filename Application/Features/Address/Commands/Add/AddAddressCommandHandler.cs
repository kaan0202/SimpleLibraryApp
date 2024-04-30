using Application.Repositories.Address;
using Application.UnitOfWork;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Add
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommandRequest, BaseResponse>
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IAddressWriteRepository _addressWriteRepository;
        public AddAddressCommandHandler(IAddressWriteRepository addressWriteRepository, IUnitOfWork unitOfWork)
        {
            _addressWriteRepository = addressWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(AddAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _addressWriteRepository.AddAsync(request.Address);
           await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Adres Eklendi");

           
        }
    }
}
