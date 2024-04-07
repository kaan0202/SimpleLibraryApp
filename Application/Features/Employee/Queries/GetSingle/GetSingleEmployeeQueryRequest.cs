using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetSingle
{
    public class GetSingleEmployeeQueryRequest:IRequest<GetSingleEmployeeQueryResponse>
    {
        public int Id { get; set; }
    }
}
