using Application.DTOs.AddressDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Update
{
    public class UpdateAddressCommandRequest:IRequest<BaseResponse>
    {
        public CommandAddressDto  Address { get; set; }

    }
}
