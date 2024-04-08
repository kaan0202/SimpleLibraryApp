
using Application.Repositories.Basket;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetById
{
    public class GetByIdBasketQueryHandler : IRequestHandler<GetByIdBasketQueryRequest, BaseDataResponse<Domain.Entities.Basket>>
    {
        readonly IBasketReadRepository _repository;

        public GetByIdBasketQueryHandler(IBasketReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseDataResponse<Domain.Entities.Basket>> Handle(GetByIdBasketQueryRequest request, CancellationToken cancellationToken)
        {
            bool result = await _repository.AnyAsync(data => data.Id == request.Id && data.PersonId == request.PersonId,false);
            if (result)
            {
                var basket = await _repository.GetByIdAsync(request.Id);
                return new SuccessDataResponse<Domain.Entities.Basket>(basket);

            }
            throw new Exception("Hata");
        }
    }
}
