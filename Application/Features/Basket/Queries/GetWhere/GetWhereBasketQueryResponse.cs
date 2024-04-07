 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetWhere
{
    public class GetWhereBasketQueryResponse
    {
        public IQueryable<Domain.Entities.Basket> Basket { get; set; }
    }
}
