using Application.DTOs.AddressDto;
using Application.Exceptions;
using Application.Repositories.Address;
using Domain.Entities;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Queries.GetById
{
    public class GetByIdAddressQueryHandler : IRequestHandler<GetByIdAddressQueryRequest, BaseDataResponse<QueryAddressDto>>
    {
        readonly IAddressReadRepository _addressReadRepository;
        public GetByIdAddressQueryHandler(IAddressReadRepository addressReadRepository)
        {
            _addressReadRepository = addressReadRepository;
        }
        public async Task<BaseDataResponse<QueryAddressDto>> Handle(GetByIdAddressQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _addressReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
               var address = await _addressReadRepository.GetByIdAsync(request.Id);
                QueryAddressDto queryAddressDto = new();
                queryAddressDto.NeighboorHood = new()
                {
                    
                    Name =address.NeighboorHood.Name,

                };
                queryAddressDto.Person = new()
                {
                    Name = address.Person.Name,
                    Email = address.Person.Email,
                    Password = address.Person.Password,
                    Surname = address.Person.Surname,
                };
                queryAddressDto.PhoneNumber = address.PhoneNumber;
                queryAddressDto.OpenAddress = address.OpenAddress;
                queryAddressDto.AddressTitle = address.AddressTitle;
                queryAddressDto.Description = address.Description;


                return new SuccessDataResponse<QueryAddressDto>(queryAddressDto);
                
            }
            throw new NotFoundException("Hata");
        }
    }
}
