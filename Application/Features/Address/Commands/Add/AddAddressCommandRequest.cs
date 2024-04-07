using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Add
{
    public class AddAddressCommandRequest:IRequest<AddAddressCommandResponse>
    {
        public Domain.Entities.Address Address { get; set; }
    }
}
