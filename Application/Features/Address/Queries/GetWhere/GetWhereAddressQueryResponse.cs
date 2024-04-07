using Application.DTOs.AddressDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Queries.Where
{
    public class GetWhereAddressQueryResponse
    {
        public IQueryable<Domain.Entities.Address> Address { get; set; }
    }
}
