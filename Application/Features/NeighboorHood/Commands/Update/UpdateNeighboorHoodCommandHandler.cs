using Application.Repositories.NeighboorHood;
using Application.UnitOfWork;
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
        readonly IUnitOfWork _unitOfWork;
        public UpdateNeighboorHoodCommandHandler(INeighboorHoodReadRepository neighboorHoodReadRepository, INeighBoorHoodWriteRepository neighBoorHoodWriteRepository, IUnitOfWork unitOfWork)
        {
            _neighboorHoodReadRepository = neighboorHoodReadRepository;
            _neighboorHoodWriteRepository = neighBoorHoodWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(UpdateNeighboorHoodCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _neighboorHoodReadRepository.AnyAsync(data => data.Id == request.NeighboorHoodDto.Id, false);
            if (result) {
                Domain.Entities.NeighboorHood neighboorHood = new()
                {

                    Name = request.NeighboorHoodDto.Name,

                };
                _neighboorHoodWriteRepository.Update(neighboorHood);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Mahalle Güncellendi");
            }
            throw new Exception("Hata");
        }
    }
}
