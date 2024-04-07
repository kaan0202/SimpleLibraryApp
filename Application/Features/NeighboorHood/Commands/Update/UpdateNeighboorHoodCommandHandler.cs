using Application.Repositories.NeighboorHood;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Update
{
    public class UpdateNeighboorHoodCommandHandler : IRequestHandler<UpdateNeighboorHoodCommandRequest, UpdateNeighboorHoodCommandResponse>
    {
        readonly INeighboorHoodReadRepository _neighboorHoodReadRepository;
        readonly INeighBoorHoodWriteRepository _neighboorHoodWriteRepository;
        public UpdateNeighboorHoodCommandHandler(INeighboorHoodReadRepository neighboorHoodReadRepository, INeighBoorHoodWriteRepository neighBoorHoodWriteRepository)
        {
            _neighboorHoodReadRepository = neighboorHoodReadRepository;
            _neighboorHoodWriteRepository = neighBoorHoodWriteRepository;
        }
        async Task<UpdateNeighboorHoodCommandResponse> IRequestHandler<UpdateNeighboorHoodCommandRequest, UpdateNeighboorHoodCommandResponse>.Handle(UpdateNeighboorHoodCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _neighboorHoodReadRepository.AnyAsync(data => data.Id == request.NeighboorHood.Id, false);
            if (result) { 
                _neighboorHoodWriteRepository.Update(request.NeighboorHood);
                return new();
            }
            throw new Exception("Hata");
        }
    }
}
