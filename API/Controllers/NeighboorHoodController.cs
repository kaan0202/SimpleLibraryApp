using API.Controllers.Common;

using Application.Features.NeighboorHood.Commands.Add;
using Application.Features.NeighboorHood.Commands.Delete;
using Application.Features.NeighboorHood.Commands.Update;
using Application.Features.NeighboorHood.Queries.GetAll;
using Application.Features.NeighboorHood.Queries.GetById;
using Application.Features.NeighboorHood.Queries.GetSingle;
using MediatR;
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
        public async void AddAuthor([FromBody] AddNeighboorHoodCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async void UpdateAuthor([FromQuery] UpdateNeighboorHoodCommandRequest request)
            => await NoDataResponse(request);

        [HttpDelete]
        public async void DeleteAuthor([FromQuery] DeleteNeighboorHoodCommandRequest request)
            => await NoDataResponse(request);

        [HttpGet]
        public async void GetAllAuthors(GetAllNeighboorHoodQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async void GetByIdAuthor([FromQuery] GetByIdNeighboorHoodQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async void GetSingleOrDefaultAuthor([FromQuery] GetSingleNeighboorHoodQueryRequest request)
            => await DataResponse(request);
    }
}
