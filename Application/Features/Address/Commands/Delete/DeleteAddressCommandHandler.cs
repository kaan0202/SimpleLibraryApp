using Application.Repositories.Address;
using Application.UnitOfWork;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Delete
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, BaseResponse>
    {
        readonly IAddressWriteRepository _addressWriteRepository;
        readonly IAddressReadRepository _addressReadRepository;
        readonly IUnitOfWork _unitOfWork;
        public DeleteAddressCommandHandler(IAddressWriteRepository addressWriteRepository, IAddressReadRepository addressReadRepository, IUnitOfWork unitOfWork)
        {
            _addressWriteRepository = addressWriteRepository;
            _addressReadRepository = addressReadRepository;
            _unitOfWork = unitOfWork;
        }
        async Task<BaseResponse> IRequestHandler<DeleteAddressCommandRequest, BaseResponse>.Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
          bool result =  await _addressReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if(result == true)
            {
                await _addressWriteRepository.RemoveByIdAsync(request.Id);
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Adres Silindi");
            }
            throw new Exception("Hata");
        }
    }
}
