using Application.Repositories.Employee;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands.Update
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommandRequest, BaseResponse>
    {
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;
        public UpdateEmployeeCommandHandler(IEmployeeWriteRepository employeeWriteRepository,IEmployeeReadRepository employeeReadRepository )

        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
        }
        public async Task<BaseResponse> Handle(UpdateEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _employeeReadRepository.AnyAsync(data => data.Id == request.Employee.Id, false);
            if (result)
            {
                _employeeWriteRepository.Update(request.Employee);
                return new SuccessWithNoDataResponse("Çalışan Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
