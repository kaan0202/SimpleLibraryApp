using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetWhere
{
    public class GetWhereNeighboorHoodQueryResponse
    {
        public IQueryable<Domain.Entities.NeighboorHood> NeighboorHoods { get; set; }
    }
}
