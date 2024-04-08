using Application.Repositories.NeighboorHood;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Delete
{
    public class DeleteNeighboorHoodCommandHandler : IRequestHandler<DeleteNeighboorHoodCommandRequest, BaseResponse>
    {
        readonly INeighBoorHoodWriteRepository _neighBoorHoodWriteRepository;
        readonly INeighboorHoodReadRepository _neighboorHoodReadRepository;
        public DeleteNeighboorHoodCommandHandler(INeighboorHoodReadRepository neighboorHoodReadRepository,INeighBoorHoodWriteRepository neighBoorHoodWriteRepository)
        {
            _neighboorHoodReadRepository = neighboorHoodReadRepository;
            _neighBoorHoodWriteRepository =neighBoorHoodWriteRepository;
        }
       public async Task<BaseResponse> Handle(DeleteNeighboorHoodCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _neighboorHoodReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
               await _neighBoorHoodWriteRepository.RemoveByIdAsync(request.Id);
                return new SuccessWithNoDataResponse("Mahalle Silindi");

            }
            throw new Exception("Hata");
        }
    }
}
