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

namespace Application.Features.Basket.Commands.Add
{
    public class AddBasketCommandHandler : IRequestHandler<AddBasketCommandRequest, BaseResponse>
    {
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IUnitOfWork _unitOfWork;
        public AddBasketCommandHandler(IBasketWriteRepository basketWriteRepository, IUnitOfWork unitOfWork)
        {
            _basketWriteRepository = basketWriteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(AddBasketCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketWriteRepository.AddAsync(request.Basket);
            await _unitOfWork.SaveChangesAsync();
            return new SuccessWithNoDataResponse("Sepete eklendi");
        }
    }
}
