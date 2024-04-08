using Application.DTOs.EmployeeDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetAll
{
    public class GetAllEmployeeQueryRequest:IRequest<BaseDataResponse<List<QueryEmployeeDto>>>
    {

    }
}
