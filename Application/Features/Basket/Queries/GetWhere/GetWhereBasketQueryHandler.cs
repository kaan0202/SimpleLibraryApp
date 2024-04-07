using Application.Repositories.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetWhere
{
    public class GetWhereBasketQueryHandler : IRequestHandler<GetWhereBasketQueryRequest, GetWhereBasketQueryResponse>
    {
        readonly IBasketReadRepository _basketReadRepository;

        public GetWhereBasketQueryHandler(IBasketReadRepository basketReadRepository)
        {
            _basketReadRepository = basketReadRepository;
        }

        async Task<GetWhereBasketQueryResponse> IRequestHandler<GetWhereBasketQueryRequest, GetWhereBasketQueryResponse>.Handle(GetWhereBasketQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _basketReadRepository.AnyAsync(data => data.Id == request.Id && data.PersonId == request.PersonId,false);
            if (result)
            {
                var basket = _basketReadRepository.GetWhere(data => data.Id == request.Id && data.PersonId == request.PersonId, false);
                return new()
                {
                    Basket = basket
                };
            }
            throw new Exception("Hata");

        }
    }
}
