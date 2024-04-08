using Application.DTOs.NeighboorHoodDto;
using Application.Repositories.NeighboorHood;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetAll
{
    public class GetAllNeighboorHoodQueryHandler : IRequestHandler<GetAllNeighboorHoodQueryRequest, BaseDataResponse<List<QueryNeighboorHoodDto>>>
    {
        readonly INeighboorHoodReadRepository _repository;

        public GetAllNeighboorHoodQueryHandler(INeighboorHoodReadRepository repository)
        {
            _repository = repository;
        }

      public  async Task<BaseDataResponse<List<QueryNeighboorHoodDto>>> Handle(GetAllNeighboorHoodQueryRequest request, CancellationToken cancellationToken)
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
            return new SuccessDataResponse<List<QueryNeighboorHoodDto>>(queryNeighboorHoodDtos);
            
        }
    }
}
