using Application.Repositories.Employee;
using Application.UnitOfWork;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands.Add
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommandRequest, BaseResponse>
    {
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IUnitOfWork _unitOfWork;
        public AddEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeWriteRepository = employeeWriteRepository;
        }
        public async Task<BaseResponse> Handle(AddEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Employee employee = new()
            {
                 Gender = request.EmployeeDto.Gender,
                 Name = request.EmployeeDto.Name,
                 Salary = request.EmployeeDto.Salary,
                 Status = request.EmployeeDto.Status,
                 Surname = request.EmployeeDto.Surname,
                 
            };
            await _employeeWriteRepository.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Çalışan Eklendi");
        }
    }
}
