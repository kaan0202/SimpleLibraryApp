﻿using Application.DTOs.EmployeeDto;
using Application.Repositories.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetById
{
    public class GetByIdEmployeeQueryHandler : IRequestHandler<GetByIdEmployeeQueryRequest, GetByIdEmployeeQueryResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;

        public GetByIdEmployeeQueryHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        async Task<GetByIdEmployeeQueryResponse> IRequestHandler<GetByIdEmployeeQueryRequest, GetByIdEmployeeQueryResponse>.Handle(GetByIdEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _employeeReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var employee = await _employeeReadRepository.GetByIdAsync(request.Id,false);
                QueryEmployeeDto queryEmployeeDto = new();
                queryEmployeeDto.Surname= employee.Surname;
                queryEmployeeDto.Salary= employee.Salary;
                queryEmployeeDto.Status= employee.Status;
                queryEmployeeDto.Gender= employee.Gender;
                queryEmployeeDto.Id = request.Id;
                queryEmployeeDto.Name = employee.Name;
                return new()
                {
                    EmployeeDto = queryEmployeeDto
                };

            }
            throw new Exception("Hata");
        }
    }
}