using Application.DTOs.EmployeeDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetSingle
{
    public class GetSingleEmployeeQueryRequest:IRequest<BaseDataResponse<QueryEmployeeDto>>
    {
        public int Id { get; set; }
    }
}
