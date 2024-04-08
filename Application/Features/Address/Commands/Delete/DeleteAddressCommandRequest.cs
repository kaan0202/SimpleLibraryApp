using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Delete
{
    public class DeleteAddressCommandRequest:IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
