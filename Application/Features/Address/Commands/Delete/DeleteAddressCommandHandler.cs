using Application.Repositories.Address;
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
        public DeleteAddressCommandHandler(IAddressWriteRepository addressWriteRepository, IAddressReadRepository addressReadRepository)
        {
            _addressWriteRepository = addressWriteRepository;
            _addressReadRepository = addressReadRepository;

        }
        async Task<BaseResponse> IRequestHandler<DeleteAddressCommandRequest, BaseResponse>.Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
          bool result =  await _addressReadRepository.AnyAsync(data => data.Id == request.Id,false);
            if(result == true)
            {
                await _addressWriteRepository.RemoveByIdAsync(request.Id);
                return new SuccessWithNoDataResponse("Adres Silindi");
            }
            throw new Exception("Hata");
        }
    }
}
