using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Update
{
    public class UpdateNeighboorHoodCommandRequest : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
