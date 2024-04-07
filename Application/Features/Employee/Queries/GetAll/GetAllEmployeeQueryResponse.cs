using Application.DTOs.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetAll
{
    public class GetAllEmployeeQueryResponse
    {
        public List<QueryEmployeeDto> EmployeeDtos { get; set; }
    }
}
