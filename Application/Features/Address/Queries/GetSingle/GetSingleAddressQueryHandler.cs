using Application.DTOs.AddressDto;
using Application.Features.Address.Queries.GetById;
using Application.Repositories.Address;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Queries.GetSingle
{
    public class GetSingleAddressQueryHandler : IRequestHandler<GetSingleAddressQueryRequest, BaseDataResponse<QueryAddressDto>>
    {
        readonly IAddressReadRepository _addressReadRepository;

        public GetSingleAddressQueryHandler(IAddressReadRepository addressReadRepository)
        {
            _addressReadRepository = addressReadRepository;
        }

        public async Task<BaseDataResponse<QueryAddressDto>> Handle(GetSingleAddressQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _addressReadRepository.AnyAsync(data => data.Id == request.Id, false);
            if (result)
            {
                var address = await _addressReadRepository.GetSingleAsync(data => data.Id == request.Id, false);
                QueryAddressDto queryAddressDto = new();
                queryAddressDto.Id = request.Id;
                queryAddressDto.PhoneNumber =queryAddressDto.PhoneNumber;
                queryAddressDto.OpenAddress =queryAddressDto.OpenAddress;
                queryAddressDto.AddressTitle =queryAddressDto.AddressTitle;
                
                queryAddressDto.Description =queryAddressDto.Description;
                queryAddressDto.Person = new()
                {
                    Email = address.Person.Email,
                    Name = address.Person.Name,
                    Password = address.Person.Password,
                    Surname = address.Person.Surname,
                };
                queryAddressDto.NeighboorHood = new()
                {
                    
                    Name = address.NeighboorHood.Name,
                };
                return new SuccessDataResponse<QueryAddressDto>(queryAddressDto);
            }
            throw new Exception("Hata");

        }

       
        }
    }


