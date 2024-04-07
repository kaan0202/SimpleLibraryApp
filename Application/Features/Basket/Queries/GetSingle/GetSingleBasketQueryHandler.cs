using Application.Repositories.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetSingle
{
    public class GetSingleBasketQueryHandler : IRequestHandler<GetSingleBasketQueryRequest, GetSingleBasketQueryResponse>
    {
        readonly IBasketReadRepository _repository;

        public GetSingleBasketQueryHandler(IBasketReadRepository repository)
        {
            _repository = repository;
        }

        async Task<GetSingleBasketQueryResponse> IRequestHandler<GetSingleBasketQueryRequest, GetSingleBasketQueryResponse>.Handle(GetSingleBasketQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _repository.AnyAsync(data => data.Id == request.Id && data.PersonId == request.PersonId,false);
            if (result)
            {
                var basket = await _repository.GetSingleAsync(data => data.Id == request.Id && data.PersonId == request.PersonId, false);
                return new()
                {
                    Basket = basket
                };
            }
            throw new Exception("Hata");
        }
    }
}
