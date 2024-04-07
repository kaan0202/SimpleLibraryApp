using Application.Repositories.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>
    {
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        public UpdateEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository,IEmployeeReadRepository employeeReadRepository )

        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }
        async Task<UpdateEmployeeCommandResponse> IRequestHandler<UpdateEmployeeCommandRequest, UpdateEmployeeCommandResponse>.Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _employeeReadRepository.AnyAsync(data => data.Id == request.Employee.Id, false);
            if (result)
            {
                _employeeWriteRepository.Update(request.Employee);
                return new();
            }
            throw new Exception("Hata");
        }
    }
}
