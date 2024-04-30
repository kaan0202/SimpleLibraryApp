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

namespace Application.Features.Employee.Commands.Delete
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommandRequest, BaseResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;
        readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IUnitOfWork _unitOfWork;
        public DeleteEmployeeCommandHandler(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository, IUnitOfWork unitOfWork)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(DeleteEmployeeCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _employeeReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                await _employeeWriteRepository.RemoveByIdAsync(request.Id);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Çalışan Silindi");
            }
            throw new Exception("Hata");
        }
    }
}
