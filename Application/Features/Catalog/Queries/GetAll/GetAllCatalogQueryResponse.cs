using Application.DTOs.CatalogDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetAll
{
    public class GetAllCatalogQueryResponse
    {
        public List<QueryCatalogDto> CatalogDtos { get; set; }
    }
}
