using Application.DTOs.CatalogDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetAll
{
    public class GetAllCatalogQueryRequest:IRequest<BaseDataResponse<List<QueryCatalogDto>>>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
