using Application.Repositories.Basket;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Commands.Update
{
    public class UpdateBasketCommandHandler : IRequestHandler<UpdateBasketCommandRequest, BaseResponse>
    { 
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketReadRepository _basketReadRepository;

        public UpdateBasketCommandHandler(IBasketWriteRepository basketWriteRepository,IBasketReadRepository basketReadRepository)
        {
            _basketWriteRepository = basketWriteRepository;
            _basketReadRepository = basketReadRepository;
        }

        public async Task<BaseResponse> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _basketReadRepository.AnyAsync(data => data.Id == request.Basket.Id);
            if (result)
            {
                _basketWriteRepository.Update(request.Basket);
                return new SuccessWithNoDataResponse("Sepet Güncellendi");
            }
            throw new Exception("Hata");
           
        }
    }
}
