using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Queries.GetSingle
{
    public class GetSinglePersonQueryRequest:IRequest<GetSinglePersonQueryResponse>
    {
        public int Id { get; set; }
    }
}
