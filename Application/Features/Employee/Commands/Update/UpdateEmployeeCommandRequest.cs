using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands.Update
{
    public class UpdateEmployeeCommandRequest:IRequest<UpdateEmployeeCommandResponse>
    {
        public Domain.Entities.Employee Employee { get; set; }
    }
}
