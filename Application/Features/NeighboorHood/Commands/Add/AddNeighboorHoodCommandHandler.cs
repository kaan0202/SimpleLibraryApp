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

namespace Application.Features.NeighboorHood.Commands.Add
{
    public class AddNeighboorHoodCommandHandler : IRequestHandler<AddNeighboorHoodCommandRequest, BaseResponse>
    {
        readonly INeighBoorHoodWriteRepository _neighBoorHoodWriteRepository;
        readonly IUnitOfWork _unitOfWork;
        public AddNeighboorHoodCommandHandler(INeighBoorHoodWriteRepository neighBoorHoodWriteRepository, IUnitOfWork unitOfWork)
        {
            _neighBoorHoodWriteRepository = neighBoorHoodWriteRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResponse> Handle(AddNeighboorHoodCommandRequest request, CancellationToken cancellationToken)
        {
            await _neighBoorHoodWriteRepository.AddAsync(request.NeighboorHood);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Mahalle eklendi");
        }
    }
}
