using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetSingle
{
    public class GetSingleCatalogQueryRequest:IRequest<GetSingleCatalogQueryResponse>
    {
        public int Id { get; set; }
    }
}
