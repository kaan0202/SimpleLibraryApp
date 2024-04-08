using Application.DTOs.NeighboorHoodDto;
using Application.Repositories.NeighboorHood;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetSingle
{
    public class GetSingleNeighboorHoodQueryHandler : IRequestHandler<GetSingleNeighboorHoodQueryRequest, BaseDataResponse<QueryNeighboorHoodDto>>
    {
        readonly INeighboorHoodReadRepository _repository;

        public GetSingleNeighboorHoodQueryHandler(INeighboorHoodReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseDataResponse<QueryNeighboorHoodDto>> Handle(GetSingleNeighboorHoodQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _repository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var neighboorHood = await _repository.GetSingleAsync(data => data.Id == request.Id,false);
                QueryNeighboorHoodDto queryNeighboorHoodDto = new();
                return new SuccessDataResponse<QueryNeighboorHoodDto>(queryNeighboorHoodDto);
            }
            throw new Exception("Hata");
        }
    }
}
