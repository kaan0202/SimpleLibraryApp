using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetById
{
    public class GetByIdEmployeeQueryRequest:IRequest<GetByIdEmployeeQueryResponse>
    {
        public int Id { get; set; }
    }
}
