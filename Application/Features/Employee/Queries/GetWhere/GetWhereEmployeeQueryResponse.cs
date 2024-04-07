using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetWhere
{
    public class GetWhereEmployeeQueryResponse
    {
        public IQueryable<Domain.Entities.Employee> Employee { get; set; }
    }
}
