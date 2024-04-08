using Application.Repositories.Basket;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Commands.Add
{
    public class AddBasketCommandHandler : IRequestHandler<AddBasketCommandRequest, BaseResponse>
    {
        readonly IBasketWriteRepository _basketWriteRepository;

        public AddBasketCommandHandler(IBasketWriteRepository basketWriteRepository)
        {
            _basketWriteRepository = basketWriteRepository;
        }

       public async Task<BaseResponse> Handle(AddBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketWriteRepository.AddAsync(request.Basket);
            return new SuccessWithNoDataResponse("Sepete eklendi");
        }
    }
}
