using Application.Repositories.NeighboorHood;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Update
{
    public class UpdateNeighboorHoodCommandHandler : IRequestHandler<UpdateNeighboorHoodCommandRequest, BaseResponse>
    {
        readonly INeighboorHoodReadRepository _neighboorHoodReadRepository;
        readonly INeighBoorHoodWriteRepository _neighboorHoodWriteRepository;
        public UpdateNeighboorHoodCommandHandler(INeighboorHoodReadRepository neighboorHoodReadRepository, INeighBoorHoodWriteRepository neighBoorHoodWriteRepository)
        {
            _neighboorHoodReadRepository = neighboorHoodReadRepository;
            _neighboorHoodWriteRepository = neighBoorHoodWriteRepository;
        }
        public async Task<BaseResponse> Handle(UpdateNeighboorHoodCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _neighboorHoodReadRepository.AnyAsync(data => data.Id == request.NeighboorHood.Id, false);
            if (result) { 
                _neighboorHoodWriteRepository.Update(request.NeighboorHood);
                return new SuccessWithNoDataResponse("Mahalle Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
