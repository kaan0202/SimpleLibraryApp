using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands.Add
{
    public class AddEmployeeCommandRequest:IRequest<AddEmployeeCommandResponse>
    {
        public Domain.Entities.Employee Employee { get; set; }
    }
}
