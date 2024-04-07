using Application.DTOs.AddressDto;
using Application.Repositories.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Queries.Where
{
    public class GetWhereAddressQueryHandler : IRequestHandler<GetWhereAddressQueryRequest, GetWhereAddressQueryResponse>
    {
        readonly IAddressReadRepository _addressReadRepository;
        public GetWhereAddressQueryHandler(IAddressReadRepository addressReadRepository)
        {
            _addressReadRepository = addressReadRepository;
        }
        async Task<GetWhereAddressQueryResponse> IRequestHandler<GetWhereAddressQueryRequest, GetWhereAddressQueryResponse>.Handle(GetWhereAddressQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _addressReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var address =  _addressReadRepository.GetWhere(data => data.Id == request.Id,false);
                return new()
                {
                    Address = address
                };
                
               
            }
            throw new Exception("Hata");
        }
    }
}
