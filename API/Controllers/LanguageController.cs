using API.Controllers.Common;
using Application.Features.Language.Commands.Add;
using Application.Features.Language.Commands.Update;
using Application.Features.Language.Queries.GetAll;
using Application.Features.Language.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class LanguageController : BaseController
    {
        public LanguageController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async void AddLanguage([FromBody] AddLanguageCommandRequest request)
             => await NoDataResponse(request);

        [HttpPut]
        public async void UpdateLanguage([FromBody] UpdateLanguageCommandRequest request)
            => await NoDataResponse(request);

        [HttpGet]
        public async Task<IActionResult> GetAllLanguages([FromQuery] GetAllLanguageQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdLanguage([FromQuery] GetByIdLanguageQueryRequest request)
           => await DataResponse(request);

    }
}
