using API.Controllers.Common;

using Application.Features.Employee.Commands.Add;
using Application.Features.Employee.Commands.Delete;
using Application.Features.Employee.Commands.Update;
using Application.Features.Employee.Queries.GetAll;
using Application.Features.Employee.Queries.GetById;
using Application.Features.Employee.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    public class EmployeeController : BaseController
    {
        public EmployeeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async void AddEmployee([FromBody] AddEmployeeCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async void UpdateAuthor([FromQuery] UpdateEmployeeCommandRequest request)
            => await NoDataResponse(request);

        [HttpDelete]
        public async void DeleteAuthor([FromQuery] DeleteEmployeeCommandRequest request)
            => await NoDataResponse(request);

        [HttpGet]
        public async void GetAllAuthors(GetAllEmployeeQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async void GetByIdAuthor([FromQuery] GetByIdEmployeeQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async void GetSingleOrDefaultAuthor([FromQuery] GetSingleEmployeeQueryRequest request)
            => await DataResponse(request);
    }
}
