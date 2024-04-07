using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetWhere
{
    public class GetWhereNeighboorHoodQueryRequest:IRequest<GetWhereNeighboorHoodQueryResponse>
    {
        public int Id { get; set; }
    }
}
