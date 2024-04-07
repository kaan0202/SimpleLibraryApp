using Application.Repositories.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands.Add
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommandRequest, AddEmployeeCommandResponse>
    {
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        public AddEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeWriteRepository = employeeWriteRepository;
        }
        async Task<AddEmployeeCommandResponse> IRequestHandler<AddEmployeeCommandRequest, AddEmployeeCommandResponse>.Handle(AddEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await _employeeWriteRepository.AddAsync(request.Employee);
            return new();
        }
    }
}
