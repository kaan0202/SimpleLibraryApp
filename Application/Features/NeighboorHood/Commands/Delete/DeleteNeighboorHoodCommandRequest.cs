using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Delete
{
    public class DeleteNeighboorHoodCommandRequest:IRequest<DeleteNeighboorHoodCommandResponse>
    {
        public int Id { get; set; }
    }
}
