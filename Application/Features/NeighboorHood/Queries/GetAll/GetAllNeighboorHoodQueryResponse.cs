using Application.DTOs.NeighboorHoodDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetAll
{
    public class GetAllNeighboorHoodQueryResponse
    {
        public List<QueryNeighboorHoodDto> NeighboorHoodDtos { get; set; }
    }
}
