using Application.DTOs.AddressDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Add
{
    public class AddAddressCommandRequest:IRequest<BaseResponse>
    {
        public CommandAddressDto Address { get; set; }
    }
}
