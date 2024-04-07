using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetWhere
{
    public class GetWhereBookQueryRequest: IRequest<GetWhereBookQueryResponse>
    {
        public int Id { get; set; }
    }
}
