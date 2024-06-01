using Application.DTOs.EmployeeDto;
using Application.Features.Address.Queries.GetAll;
using Application.Repositories.Employee;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetAll
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQueryRequest, BaseDataResponse<List<QueryEmployeeDto>>>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;

        public GetAllEmployeeQueryHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<BaseDataResponse<List<QueryEmployeeDto>>> Handle(GetAllEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            var totalCount = _employeeReadRepository.GetAll(false).Count();
            var employees = await _employeeReadRepository.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).ToListAsync();
            List<QueryEmployeeDto> queryEmployeeDtos = new();
            foreach (var employee in employees)
            {
                QueryEmployeeDto queryEmployeeDto = new();
                queryEmployeeDto.Salary = employee.Salary;
                queryEmployeeDto.Surname = employee.Surname;
                queryEmployeeDto.Name = employee.Name;
                queryEmployeeDto.Status = employee.Status;
                queryEmployeeDto.Gender = employee.Gender;
                queryEmployeeDto.Id = employee.Id;
                queryEmployeeDtos.Add(queryEmployeeDto);
            }
            return new SuccessDataResponse<List<QueryEmployeeDto>>(queryEmployeeDtos, totalCount);
           
        }
        
    }
}
