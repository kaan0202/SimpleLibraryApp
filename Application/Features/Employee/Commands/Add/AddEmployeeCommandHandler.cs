using Application.Repositories.Employee;
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
        public AddEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository)
        {
            _employeeWriteRepository = employeeWriteRepository;
        }
        public async Task<BaseResponse> Handle(AddEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            await _employeeWriteRepository.AddAsync(request.Employee);
            return new SuccessWithNoDataResponse("Çalışan Eklendi");
        }
    }
}
