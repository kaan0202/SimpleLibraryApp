using Application.DTOs.AddressDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Queries.GetAll
{
    public class GetAllAddressQueryResponse
    {
        public List<QueryAddressDto> AddressDto { get; set; }
    }
}
