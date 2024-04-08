using Application.Repositories.Basket;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetAll
{
    public class GetAllBasketQueryHandler : IRequestHandler<GetAllBasketQueryRequest, BaseDataResponse<List<Domain.Entities.Basket>>>
    {
        readonly IBasketReadRepository _repository;

        public GetAllBasketQueryHandler(IBasketReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseDataResponse<List<Domain.Entities.Basket>>> Handle(GetAllBasketQueryRequest request, CancellationToken cancellationToken)
        {
            var baskets = await _repository.GetAll(false).Where(x=>x.PersonId == request.PersonId).ToListAsync();
            return new SuccessDataResponse<List<Domain.Entities.Basket>>(baskets);
        }
    }
}
