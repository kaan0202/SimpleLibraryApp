using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Queries.GetById
{
    public class GetByIdAuthorQueryRequest:IRequest<GetByIdAuthorQueryResponse>
    {
        public int Id { get; set; }
    }
}
