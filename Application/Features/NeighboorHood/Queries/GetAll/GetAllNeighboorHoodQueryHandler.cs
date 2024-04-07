using Application.DTOs.NeighboorHoodDto;
using Application.Repositories.NeighboorHood;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetAll
{
    public class GetAllNeighboorHoodQueryHandler : IRequestHandler<GetAllNeighboorHoodQueryRequest, GetAllNeighboorHoodQueryResponse>
    {
        readonly INeighboorHoodReadRepository _repository;

        public GetAllNeighboorHoodQueryHandler(INeighboorHoodReadRepository repository)
        {
            _repository = repository;
        }

        async Task<GetAllNeighboorHoodQueryResponse> IRequestHandler<GetAllNeighboorHoodQueryRequest, GetAllNeighboorHoodQueryResponse>.Handle(GetAllNeighboorHoodQueryRequest request, CancellationToken cancellationToken)
        {
            var neighboorHoods = await _repository.GetAll().ToListAsync();
            List<QueryNeighboorHoodDto> queryNeighboorHoodDtos = new();
            foreach (var item in neighboorHoods)
            {
                QueryNeighboorHoodDto queryNeighboorHoodDto = new();
                queryNeighboorHoodDto.Id = item.Id;
                queryNeighboorHoodDto.Name = item.Name;
                queryNeighboorHoodDtos.Add(queryNeighboorHoodDto);
            }
            return new()
            {
                NeighboorHoodDtos = queryNeighboorHoodDtos
            };
        }
    }
}
