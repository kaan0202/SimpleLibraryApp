using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetWhere
{
    public class GetWhereEmployeeQueryRequest:IRequest<GetWhereEmployeeQueryResponse>
    {
        public int Id { get; set; }
    }
}
