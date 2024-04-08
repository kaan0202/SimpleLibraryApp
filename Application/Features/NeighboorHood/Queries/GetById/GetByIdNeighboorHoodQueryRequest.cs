using Application.DTOs.NeighboorHoodDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetById
{
    public class GetByIdNeighboorHoodQueryRequest:IRequest<BaseDataResponse<QueryNeighboorHoodDto>>
    {
        public int Id { get; set; }
    }
}
