using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Commands.Add
{
    public class AddBasketCommandRequest:IRequest<BaseResponse>
    {
        public Domain.Entities.Basket Basket { get; set; }
    }
}
