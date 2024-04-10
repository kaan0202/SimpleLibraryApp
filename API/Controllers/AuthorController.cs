using API.Controllers.Common;

using Application.Features.Author.Commands.Add;
using Application.Features.Author.Commands.Delete;
using Application.Features.Author.Commands.Update;
using Application.Features.Author.Queries.GetAll;
using Application.Features.Author.Queries.GetById;
using Application.Features.Author.Queries.Single;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AuthorController : BaseController
    {
        public AuthorController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async void AddAuthor([FromBody]AddAuthorCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async void UpdateAuthor([FromQuery] UpdateAuthorCommandRequest request)
            => await NoDataResponse(request);

        [HttpDelete]
        public async void DeleteAuthor([FromQuery] DeleteAuthorCommandRequest request)
            => await NoDataResponse(request);

        [HttpGet]
         public async void GetAllAuthors(GetAllAuthorQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async void GetByIdAuthor([FromQuery] GetByIdAuthorQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async void GetSingleOrDefaultAuthor([FromQuery] GetSingleAuthorQueryRequest request)
            => await DataResponse(request);
    }
}
