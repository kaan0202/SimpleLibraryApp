using Application.DTOs.NeighboorHoodDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetAll
{
    public class GetAllNeighboorHoodQueryRequest:IRequest<BaseDataResponse<List<QueryNeighboorHoodDto>>>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
