using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetSingle
{
    public class GetSingleBookQueryRequest : IRequest<GetSingleBookQueryResponse>
    {
        public int Id { get; set; }
    }
}
