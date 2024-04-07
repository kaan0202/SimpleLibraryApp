﻿using Application.DTOs.EmployeeDto;
using Application.Features.Address.Queries.GetAll;
using Application.Repositories.Employee;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetAll
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQueryRequest, GetAllEmployeeQueryResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;

        public GetAllEmployeeQueryHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<GetAllEmployeeQueryResponse> Handle(GetAllEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            var employees = await _employeeReadRepository.GetAll(false).ToListAsync();
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
            return new()
            {
                EmployeeDtos = queryEmployeeDtos
            };
        }
        
    }
}
