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

namespace Application.Features.Address.Commands.Update
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, BaseResponse>
    {
        readonly IAddressReadRepository _addressReadRepository;
        readonly IAddressWriteRepository _addressWriteRepository;
        readonly IUnitOfWork _unitOfWork;
        public UpdateAddressCommandHandler(IAddressReadRepository addressReadRepository, IAddressWriteRepository addressWriteRepository, IUnitOfWork unitOfWork)
        {
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;
            _unitOfWork = unitOfWork;
        }
        async Task<BaseResponse> IRequestHandler<UpdateAddressCommandRequest, BaseResponse>.Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _addressReadRepository.AnyAsync(data => data.Id == request.Address.Id,false);
            if (result == true)
            {
                Domain.Entities.Address address = new()
                {
                    Id = request.Address.Id,
                    AddressTitle = request.Address.AddressTitle,
                    CreatedDate = DateTime.UtcNow,
                    Description = request.Address.Description,
                    NeighboorHoodId = request.Address.NeighboorHoodId,
                    PhoneNumber = request.Address.PhoneNumber,
                    PersonId = request.Address.PersonId,
                };

                _addressWriteRepository.Update(address);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Adres Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
