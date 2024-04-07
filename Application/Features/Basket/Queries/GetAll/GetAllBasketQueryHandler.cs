using Application.Repositories.Basket;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetAll
{
    public class GetAllBasketQueryHandler : IRequestHandler<GetAllBasketQueryRequest, GetAllBasketQueryResponse>
    {
        readonly IBasketReadRepository _repository;

        public GetAllBasketQueryHandler(IBasketReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllBasketQueryResponse> Handle(GetAllBasketQueryRequest request, CancellationToken cancellationToken)
        {
            var baskets = await _repository.GetAll(false).Where(x=>x.PersonId == request.PersonId).ToListAsync();
            return new GetAllBasketQueryResponse()
            {
                Baskets = baskets
            };
        }
    }
}
