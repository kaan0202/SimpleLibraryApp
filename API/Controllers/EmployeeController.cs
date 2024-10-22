using API.Controllers.Common;

using Application.Features.Employee.Commands.Add;
using Application.Features.Employee.Commands.Delete;
using Application.Features.Employee.Commands.Update;
using Application.Features.Employee.Queries.GetAll;
using Application.Features.Employee.Queries.GetById;
using Application.Features.Employee.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class EmployeeController : BaseController
    {
        public EmployeeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] AddEmployeeCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromQuery] UpdateEmployeeCommandRequest request)
            => await NoDataResponse(request);

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee([FromQuery] DeleteEmployeeCommandRequest request)
            => await NoDataResponse(request);

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees(GetAllEmployeeQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdEmployee([FromQuery] GetByIdEmployeeQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async Task<IActionResult> GetSingleOrDefaultEmployee([FromQuery] GetSingleEmployeeQueryRequest request)
            => await DataResponse(request);
    }
}
