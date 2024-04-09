using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.Update
{
    public class UpdateCatalogCommandRequest:IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string CatalogName { get; set; }
        public int LanguageId { get; set; }
    }
}
