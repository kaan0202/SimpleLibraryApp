using Application.Repositories.NeighboorHood;
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
        public AddNeighboorHoodCommandHandler(INeighBoorHoodWriteRepository neighBoorHoodWriteRepository)
        {
            _neighBoorHoodWriteRepository = neighBoorHoodWriteRepository;
        }
        public async Task<BaseResponse> Handle(AddNeighboorHoodCommandRequest request, CancellationToken cancellationToken)
        {
            await _neighBoorHoodWriteRepository.AddAsync(request.NeighboorHood);
            return new SuccessWithNoDataResponse("Mahalle eklendi");
        }
    }
}
