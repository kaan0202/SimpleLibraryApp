using Application.Repositories.Basket;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetSingle
{
    public class GetSingleBasketQueryHandler : IRequestHandler<GetSingleBasketQueryRequest, BaseDataResponse<Domain.Entities.Basket>>
    {
        readonly IBasketReadRepository _repository;

        public GetSingleBasketQueryHandler(IBasketReadRepository repository)
        {
            _repository = repository;
        }

       public async Task<BaseDataResponse<Domain.Entities.Basket>> Handle(GetSingleBasketQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _repository.AnyAsync(data => data.Id == request.Id && data.PersonId == request.PersonId,false);
            if (result)
            {
                var basket = await _repository.GetSingleAsync(data => data.Id == request.Id && data.PersonId == request.PersonId, false);
                return new SuccessDataResponse<Domain.Entities.Basket>(basket);
            }
            throw new Exception("Hata");
        }
    }
}
