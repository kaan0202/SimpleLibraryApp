using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Queries.GetSingle
{
    public class GetSingleAddressQueryRequest:IRequest<GetSingleAddressQueryResponse>
    {
        public int Id { get; set; }
    }
}
