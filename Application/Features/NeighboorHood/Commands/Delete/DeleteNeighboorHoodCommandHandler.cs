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

namespace Application.Features.NeighboorHood.Commands.Delete
{
    public class DeleteNeighboorHoodCommandHandler : IRequestHandler<DeleteNeighboorHoodCommandRequest, BaseResponse>
    {
        readonly INeighBoorHoodWriteRepository _neighBoorHoodWriteRepository;
        readonly INeighboorHoodReadRepository _neighboorHoodReadRepository;
        readonly IUnitOfWork _unitOfWork;
        public DeleteNeighboorHoodCommandHandler(INeighboorHoodReadRepository neighboorHoodReadRepository, INeighBoorHoodWriteRepository neighBoorHoodWriteRepository, IUnitOfWork unitOfWork)
        {
            _neighboorHoodReadRepository = neighboorHoodReadRepository;
            _neighBoorHoodWriteRepository = neighBoorHoodWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(DeleteNeighboorHoodCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _neighboorHoodReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
               await _neighBoorHoodWriteRepository.RemoveByIdAsync(request.Id);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Mahalle Silindi");

            }
            throw new Exception("Hata");
        }
    }
}
