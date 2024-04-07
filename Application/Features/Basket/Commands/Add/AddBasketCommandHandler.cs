using Application.Repositories.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Commands.Add
{
    public class AddBasketCommandHandler : IRequestHandler<AddBasketCommandRequest, AddBasketCommandResponse>
    {
        readonly IBasketWriteRepository _basketWriteRepository;

        public AddBasketCommandHandler(IBasketWriteRepository basketWriteRepository)
        {
            _basketWriteRepository = basketWriteRepository;
        }

        async Task<AddBasketCommandResponse> IRequestHandler<AddBasketCommandRequest, AddBasketCommandResponse>.Handle(AddBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketWriteRepository.AddAsync(request.Basket);
            return new();
        }
    }
}
