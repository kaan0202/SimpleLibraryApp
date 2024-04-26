using API.Controllers.Common;
using Application.Features.Book.Commands.Add;
using Application.Features.Book.Commands.Update;
using Application.Features.Book.Queries.GetAll;
using Application.Features.Book.Queries.GetById;
using Application.Features.Book.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Admin")]
    public class BookController : BaseController
    {
        public BookController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async void AddBook([FromBody] AddBookCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async void UpdateBook([FromQuery] UpdateBookCommandRequest request)
            => await NoDataResponse(request);

      

        [HttpGet]
        public async void GetAllAuthors(GetAllBookQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async void GetByIdBook([FromQuery] GetByIdBookQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async void GetSingleOrDefaultBook([FromQuery] GetSingleBookQueryRequest request)
            => await DataResponse(request);

    }
}
