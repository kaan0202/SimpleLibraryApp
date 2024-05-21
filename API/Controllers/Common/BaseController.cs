using Domain.Results.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [NonAction]
        public async Task<IActionResult> NoDataResponse(IRequest<BaseResponse> request)
        {
            BaseResponse response = await _mediator.Send(request);
            if(!response.Success) 
              return BadRequest(response);
            
            return Ok(response);
        }
        [NonAction]
        public async Task<IActionResult> DataResponse<TResponseParameters>(IRequest<BaseDataResponse<TResponseParameters>> request)
           where TResponseParameters : class, new()
        {
            var response = await _mediator.Send(request);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
