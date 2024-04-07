using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Queries.GetWhere
{
    public class GetWhereLanguageQueryRequest:IRequest<GetWhereLanguageQueryResponse>
    {
        public int Id { get; set; }
    }
}
