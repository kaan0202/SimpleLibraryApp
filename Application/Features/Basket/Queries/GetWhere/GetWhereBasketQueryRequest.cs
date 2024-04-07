using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetWhere
{
    public class GetWhereBasketQueryRequest:IRequest<GetWhereBasketQueryResponse>
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
    }
}
