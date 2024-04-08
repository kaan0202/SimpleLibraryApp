using Application.DTOs.AddressDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Queries.GetAll
{
    public class GetAllAddressQueryRequest:IRequest<BaseDataResponse<List<QueryAddressDto>>>
    {
      
    }
}
