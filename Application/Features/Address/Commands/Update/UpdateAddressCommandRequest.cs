using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Update
{
    public class UpdateAddressCommandRequest:IRequest<UpdateAddressCommandResponse>
    {
        public Domain.Entities.Address Address { get; set; }
    }
}
