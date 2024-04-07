using Application.Repositories.Employee;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Queries.GetWhere
{
    public class GetWhereEmployeeQueryHandler : IRequestHandler<GetWhereEmployeeQueryRequest, GetWhereEmployeeQueryResponse>
    {
        readonly IEmployeeReadRepository _employeeReadRepository;

        public GetWhereEmployeeQueryHandler(IEmployeeReadRepository employeeReadRepository)
        {
            _employeeReadRepository = employeeReadRepository;
        }

        async Task<GetWhereEmployeeQueryResponse> IRequestHandler<GetWhereEmployeeQueryRequest, GetWhereEmployeeQueryResponse>.Handle(GetWhereEmployeeQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _employeeReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var employee = _employeeReadRepository.GetWhere(data => data.Id == request.Id, false);
                return new()
                {
                    Employee = employee,
                };
            }
            throw new Exception("Hata");
        }
    }
}
