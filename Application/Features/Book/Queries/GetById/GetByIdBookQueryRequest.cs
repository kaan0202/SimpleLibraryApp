using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Queries.GetById
{
    public class GetByIdBookQueryRequest : IRequest<GetByIdBookQueryResponse>
    {
        public int Id { get; set; }
    }
}
