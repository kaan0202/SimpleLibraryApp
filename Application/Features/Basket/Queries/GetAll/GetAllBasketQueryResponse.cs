using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetAll
{
    public class GetAllBasketQueryResponse
    {
        public List<Domain.Entities.Basket> Baskets { get; set; }
    }
}
