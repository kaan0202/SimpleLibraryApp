using Application.Repositories.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Update
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
    {
        readonly IAddressReadRepository _addressReadRepository;
        readonly IAddressWriteRepository _addressWriteRepository;
        public UpdateAddressCommandHandler(IAddressReadRepository addressReadRepository,IAddressWriteRepository addressWriteRepository)
        {
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;
        }
        async Task<UpdateAddressCommandResponse> IRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>.Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            bool result = await _addressReadRepository.AnyAsync(data => data.Id == request.Address.Id);
            if (result == true)
            {
                _addressWriteRepository.Update(request.Address);
                return new();
            }
            throw new Exception("Hata");
        }
    }
}
