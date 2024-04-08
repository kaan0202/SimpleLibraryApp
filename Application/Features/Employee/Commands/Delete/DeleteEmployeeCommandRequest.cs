using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands.Delete
{
    public class DeleteEmployeeCommandRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
