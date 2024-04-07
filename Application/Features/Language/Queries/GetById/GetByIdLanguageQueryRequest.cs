using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Queries.GetById
{
    public class GetByIdLanguageQueryRequest:IRequest<GetByIdLanguageQueryResponse>
    {
        public int Id { get; set; }
    }
}
