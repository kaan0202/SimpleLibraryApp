using Application.Repositories.Address;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Add
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommandRequest, AddAddressCommandResponse>
    {
        readonly IAddressWriteRepository _addressWriteRepository;
        public AddAddressCommandHandler(IAddressWriteRepository addressWriteRepository)
        {
            _addressWriteRepository = addressWriteRepository;  
        }
        public async Task<AddAddressCommandResponse> Handle(AddAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _addressWriteRepository.AddAsync(request.Address);
            return new();
           
        }
    }
}
