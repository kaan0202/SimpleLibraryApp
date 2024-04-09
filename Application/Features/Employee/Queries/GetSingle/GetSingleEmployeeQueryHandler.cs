using Application.DTOs.EmployeeDto;
using Application.Exceptions;
using Application.Repositories.Employee;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetSingle
{
    public class GetSingleEmployeeQueryHandler : IRequestHandler<GetSingleEmployeeQueryRequest, BaseDataResponse<QueryEmployeeDto>>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;

        public GetSingleEmployeeQueryHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        public async Task<BaseDataResponse<QueryEmployeeDto>> Handle(GetSingleEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _employeeReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var employee = await _employeeReadRepository.GetSingleAsync(data => data.Id ==request.Id,false);
                QueryEmployeeDto queryEmployeeDto = new();
                queryEmployeeDto.Salary=employee.Salary;
                queryEmployeeDto.Surname=employee.Surname;  
                queryEmployeeDto.Name=employee.Name;
                queryEmployeeDto.Status=employee.Status;
                queryEmployeeDto.Gender=employee.Gender;
                queryEmployeeDto.Id =employee.Id;
                return new SuccessDataResponse<QueryEmployeeDto>(queryEmployeeDto);
               
            }
            throw new NotFoundException("Hata");
        }
    }
}
