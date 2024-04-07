using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Add
{
    public class AddNeighboorHoodCommandRequest:IRequest<AddNeighboorHoodCommandResponse>
    {
        public Domain.Entities.NeighboorHood NeighboorHood { get; set; }
    }
}
