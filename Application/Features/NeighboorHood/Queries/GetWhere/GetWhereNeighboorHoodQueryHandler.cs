using Application.Repositories.NeighboorHood;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetWhere
{
    public class GetWhereNeighboorHoodQueryHandler : IRequestHandler<GetWhereNeighboorHoodQueryRequest, GetWhereNeighboorHoodQueryResponse>
    {
        readonly INeighboorHoodReadRepository _repository;

        public GetWhereNeighboorHoodQueryHandler(INeighboorHoodReadRepository repository)
        {
            _repository = repository;
        }

        async Task<GetWhereNeighboorHoodQueryResponse> IRequestHandler<GetWhereNeighboorHoodQueryRequest, GetWhereNeighboorHoodQueryResponse>.Handle(GetWhereNeighboorHoodQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _repository.AnyAsync(data => data.Id == request.Id,false);
            if (result)
            {
                var neighboorHood = _repository.GetWhere(data =>data.Id == request.Id,false);
                return new()
                {
                    NeighboorHoods = neighboorHood
                };
            }
            throw new Exception("Hata");
        }
    }
}
