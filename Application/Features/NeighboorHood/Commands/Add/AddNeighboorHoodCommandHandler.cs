using Application.Repositories.NeighboorHood;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Add
{
    public class AddNeighboorHoodCommandHandler : IRequestHandler<AddNeighboorHoodCommandRequest, AddNeighboorHoodCommandResponse>
    {
        readonly INeighBoorHoodWriteRepository _neighBoorHoodWriteRepository;
        public AddNeighboorHoodCommandHandler(INeighBoorHoodWriteRepository neighBoorHoodWriteRepository)
        {
            _neighBoorHoodWriteRepository = neighBoorHoodWriteRepository;
        }
        async Task<AddNeighboorHoodCommandResponse> IRequestHandler<AddNeighboorHoodCommandRequest, AddNeighboorHoodCommandResponse>.Handle(AddNeighboorHoodCommandRequest request, CancellationToken cancellationToken)
        {
            await _neighBoorHoodWriteRepository.AddAsync(request.NeighboorHood);
            return new();
        }
    }
}
