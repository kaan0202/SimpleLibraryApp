using Application.Repositories.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands.Delete
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        public DeleteEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository,IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }
        async Task<DeleteEmployeeCommandResponse> IRequestHandler<DeleteEmployeeCommandRequest, DeleteEmployeeCommandResponse>.Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _employeeReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                await _employeeWriteRepository.RemoveByIdAsync(request.Id);
                return new();
            }
            throw new Exception("Hata");
        }
    }
}
