using Application.DTOs.AddressDto;
using Application.Repositories.Address;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Queries.GetAll
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQueryRequest, BaseDataResponse<List<QueryAddressDto>>>
    {
        readonly IAddressReadRepository _addressReadRepository;
        public GetAllAddressQueryHandler(IAddressReadRepository addressReadRepository)
        {
            _addressReadRepository = addressReadRepository;
        }
        public async Task<BaseDataResponse<List<QueryAddressDto>>> Handle(GetAllAddressQueryRequest request, CancellationToken cancellationToken)
        {

            var addresses = await _addressReadRepository.Table.Include(x => x.Person).Include(x => x.NeighboorHood).AsNoTrackingWithIdentityResolution().ToListAsync();
            List<QueryAddressDto> addressDtos = new();
            foreach (var address in addresses)
            {
                QueryAddressDto addressDto = new();
                addressDto.Id = address.Id;
                addressDto.PhoneNumber = address.PhoneNumber;
                addressDto.OpenAddress = address.OpenAddress;
                addressDto.AddressTitle = address.AddressTitle;
                addressDto.Description = address.Description;
                addressDto.Person = new()
                {
                    Email = address.Person.Email,
                    Name = address.Person.Name,
                    Password = address.Person.Password,
                    Surname = address.Person.Surname,
                };
                addressDto.NeighboorHood = new()
                {
                    Id = address.NeighboorHoodId,
                    Name = address.NeighboorHood.Name,

                };




                addressDtos.Add(addressDto);
            }
            return new SuccessDataResponse<List<QueryAddressDto>>(addressDtos);
        }

        
    }
}
