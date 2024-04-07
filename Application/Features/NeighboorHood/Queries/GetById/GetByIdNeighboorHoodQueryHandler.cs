using Application.DTOs.NeighboorHoodDto;
using Application.Repositories.NeighboorHood;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetById
{
    public class GetByIdNeighboorHoodQueryHandler : IRequestHandler<GetByIdNeighboorHoodQueryRequest, GetByIdNeighboorHoodQueryResponse>
    {
        readonly INeighboorHoodReadRepository _repository;

        public GetByIdNeighboorHoodQueryHandler(INeighboorHoodReadRepository repository)
        {
            _repository = repository;
        }

        async Task<GetByIdNeighboorHoodQueryResponse> IRequestHandler<GetByIdNeighboorHoodQueryRequest, GetByIdNeighboorHoodQueryResponse>.Handle(GetByIdNeighboorHoodQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _repository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var neighboorHood = await _repository.GetByIdAsync(request.Id);
                QueryNeighboorHoodDto queryNeighboorHoodDto = new();
                queryNeighboorHoodDto.Id = request.Id;
                queryNeighboorHoodDto.Name = neighboorHood.Name;
                return new()
                {
                    NeighboorHoodDto = queryNeighboorHoodDto
                };
            }
            throw new Exception("Hata");
        }
    }
}
