using Application.DTOs.AddressDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Queries.GetById
{
    public class GetByIdAddressQueryRequest:IRequest<BaseDataResponse<QueryAddressDto>>
    {
        public int Id { get; set; }
    }
}
