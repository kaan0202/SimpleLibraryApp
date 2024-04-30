using Application.Repositories.Basket;
using Application.UnitOfWork;
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
        readonly IUnitOfWork _unitOfWork;

        public UpdateBasketCommandHandler(IBasketWriteRepository basketWriteRepository, IBasketReadRepository basketReadRepository, IUnitOfWork unitOfWork)
        {
            _basketWriteRepository = basketWriteRepository;
            _basketReadRepository = basketReadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(UpdateBasketCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _basketReadRepository.AnyAsync(data => data.Id == request.Id && data.PersonId == request.PersonId,false);
            if (result)
            {
                Domain.Entities.Basket basket = new()
                {
                    Books = request.Books

                };
                _basketWriteRepository.Update(basket);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Sepet Güncellendi");
            }
            throw new Exception("Hata");
           
        }
    }
}
