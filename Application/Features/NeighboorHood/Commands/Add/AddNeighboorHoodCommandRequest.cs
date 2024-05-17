using Application.DTOs.NeighboorHoodDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Add
{
    public class AddNeighboorHoodCommandRequest:IRequest<BaseResponse>
    {

        public CommandNeighboorHoodDto CommandDto { get; set; }
    }
}
