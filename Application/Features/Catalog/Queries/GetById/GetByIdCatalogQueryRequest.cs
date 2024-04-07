using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Queries.GetById
{
    public class GetByIdCatalogQueryRequest:IRequest<GetByIdCatalogQueryResponse>
    {
        public int Id { get; set; }
    }
}
