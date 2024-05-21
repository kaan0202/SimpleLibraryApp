using API.Controllers.Common;
using Application.Features.Person.Commands.Add;
using Application.Features.Person.Commands.Update;
using Application.Features.Person.Queries.GetAll;
using Application.Features.Person.Queries.GetById;
using Application.Features.Person.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class PersonController : BaseController
    {
        public PersonController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async void AddPerson([FromBody] AddPersonCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async void UpdatePerson([FromQuery] UpdatePersonCommandRequest request)
            => await NoDataResponse(request);

        

        [HttpGet]
        public async Task<IActionResult> GetAllPerson(GetAllPersonQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdPerson([FromQuery] GetByIdPersonQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async Task<IActionResult> GetSingleOrDefaultPerson([FromQuery] GetSinglePersonQueryRequest request)
            => await DataResponse(request);
    }
}
