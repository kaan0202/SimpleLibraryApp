using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.Update
{
    public class UpdateCatalogCommandRequest:IRequest<UpdateCatalogCommandResponse>
    {
        public Domain.Entities.Catalog Catalog { get; set; }
    }
}
