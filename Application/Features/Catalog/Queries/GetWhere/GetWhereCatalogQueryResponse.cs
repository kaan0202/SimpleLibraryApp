using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetWhere
{
    public class GetWhereCatalogQueryResponse
    {
        public IQueryable<Domain.Entities.Catalog> Catalog { get; set; }
    }
}
