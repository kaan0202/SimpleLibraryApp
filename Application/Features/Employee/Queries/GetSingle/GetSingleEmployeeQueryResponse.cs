using Application.DTOs.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetSingle
{
    public class GetSingleEmployeeQueryResponse
    {
        public QueryEmployeeDto EmployeeDto { get; set; }
    }
}
