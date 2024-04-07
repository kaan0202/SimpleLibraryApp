using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Queries.Where
{
    public class GetWhereAddressQueryRequest:IRequest<GetWhereAddressQueryResponse>
    {
        public int Id { get; set; }
    }
}
