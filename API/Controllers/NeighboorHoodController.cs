using API.Controllers.Common;

using Application.Features.NeighboorHood.Commands.Add;
using Application.Features.NeighboorHood.Commands.Delete;
using Application.Features.NeighboorHood.Commands.Update;
using Application.Features.NeighboorHood.Queries.GetAll;
using Application.Features.NeighboorHood.Queries.GetById;
using Application.Features.NeighboorHood.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class NeighboorHoodController : BaseController
    {
        public NeighboorHoodController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddNeighboorHood([FromBody] AddNeighboorHoodCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async Task<IActionResult> UpdateNeighboorHood([FromQuery] UpdateNeighboorHoodCommandRequest request)
            => await NoDataResponse(request);

        [HttpDelete]
        public async Task<IActionResult> DeleteNeighboorHood([FromQuery] DeleteNeighboorHoodCommandRequest request)
            => await NoDataResponse(request);

        [HttpGet]
        public async Task<IActionResult> GetAllNeighboorHood(GetAllNeighboorHoodQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdNeighboorHood([FromQuery] GetByIdNeighboorHoodQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async Task<IActionResult> GetSingleOrDefaultNeighboorHood([FromQuery] GetSingleNeighboorHoodQueryRequest request)
            => await DataResponse(request);
    }
}
