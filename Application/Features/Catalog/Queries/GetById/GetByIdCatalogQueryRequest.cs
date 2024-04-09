using Application.DTOs.CatalogDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetById
{
    public class GetByIdCatalogQueryRequest:IRequest<BaseDataResponse<QueryCatalogDto>>
    {
        public int Id { get; set; }
    }
}
