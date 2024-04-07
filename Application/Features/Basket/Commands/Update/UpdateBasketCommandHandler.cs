using Application.Repositories.Basket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Commands.Update
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest, UpdateBasketCommandResponse>
    { 
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketReadRepository _basketReadRepository;

        public UpdateBasketCommandHandler(IBasketWriteRepository basketWriteRepository,IBasketReadRepository basketReadRepository)
        {
            _basketWriteRepository = basketWriteRepository;
            _basketReadRepository = basketReadRepository;
        }

        async Task<UpdateBasketCommandResponse> IRequestHandler<UpdateBasketCommandRequest, UpdateBasketCommandResponse>.Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _basketReadRepository.AnyAsync(data => data.Id == request.Basket.Id);
            if (result)
            {
                _basketWriteRepository.Update(request.Basket);
                return new();
            }
            throw new Exception("Hata");
           
        }
    }
}
