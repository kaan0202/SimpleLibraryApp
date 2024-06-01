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
            var totalCount = _addressReadRepository.GetAll(false).Count();
            var addresses = await _addressReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
            List<QueryAddressDto> queryLanguageDtos = new();
            foreach (var address in addresses)
            {
                QueryAddressDto queryAddressDto = new();
                queryAddressDto.AddressTitle = address.AddressTitle;
                queryAddressDto.Id = address.Id;
                queryAddressDto.PhoneNumber = address.PhoneNumber;
                queryAddressDto.OpenAddress = address.OpenAddress;
                queryAddressDto.Description = address.Description;
                

                queryLanguageDtos.Add(queryAddressDto);
            }

            return new SuccessDataResponse<List<QueryAddressDto>>(queryLanguageDtos, totalCount);
        }

        
    }
}
