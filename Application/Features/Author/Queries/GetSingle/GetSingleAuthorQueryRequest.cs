using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.Single
{
    public class GetSingleAuthorQueryRequest:IRequest<GetSingleAuthorQueryResponse>
    {
        public int Id { get; set; }
    }
}
