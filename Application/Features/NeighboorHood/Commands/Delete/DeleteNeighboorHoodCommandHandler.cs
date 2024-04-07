using Application.Repositories.NeighboorHood;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Delete
{
    public class DeleteNeighboorHoodCommandHandler : IRequestHandler<DeleteNeighboorHoodCommandRequest, DeleteNeighboorHoodCommandResponse>
    {
        readonly INeighBoorHoodWriteRepository _neighBoorHoodWriteRepository;
        readonly INeighboorHoodReadRepository _neighboorHoodReadRepository;
        public DeleteNeighboorHoodCommandHandler(INeighboorHoodReadRepository neighboorHoodReadRepository,INeighBoorHoodWriteRepository neighBoorHoodWriteRepository)
        {
            _neighboorHoodReadRepository = neighboorHoodReadRepository;
            _neighBoorHoodWriteRepository =neighBoorHoodWriteRepository;
        }
        async Task<DeleteNeighboorHoodCommandResponse> IRequestHandler<DeleteNeighboorHoodCommandRequest, DeleteNeighboorHoodCommandResponse>.Handle(DeleteNeighboorHoodCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _neighboorHoodReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
               await _neighBoorHoodWriteRepository.RemoveByIdAsync(request.Id);
                return new();

            }
            throw new Exception("Hata");
        }
    }
}
