using Application.DTOs.CatalogDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetById
{
    public class GetByIdCatalogQueryResponse
    {
        public QueryCatalogDto CatalogDto { get; set; }
    }
}
