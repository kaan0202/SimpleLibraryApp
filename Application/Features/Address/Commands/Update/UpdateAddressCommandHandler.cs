﻿using Application.Repositories.Address;
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
        public UpdateAddressCommandHandler(IAddressReadRepository addressReadRepository,IAddressWriteRepository addressWriteRepository)
        {
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;
        }
        async Task<BaseResponse> IRequestHandler<UpdateAddressCommandRequest, BaseResponse>.Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _addressReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result == true)
            {
                Domain.Entities.Address address = new()
                {
                    AddressTitle = request.AddressTitle,
                    NeighboorHoodId = request.NeighboorHoodId,
                    OpenAddress = request.OpenAddress,
                    Description = request.Description,
                    PhoneNumber = request.PhoneNumber,
                    PersonId = request.PersonId,
                    
                };

                _addressWriteRepository.Update(address);
                return new SuccessWithNoDataResponse("Adres Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
