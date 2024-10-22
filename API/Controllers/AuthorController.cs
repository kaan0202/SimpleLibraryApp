using API.Controllers.Common;

using Application.Features.Author.Commands.Add;
using Application.Features.Author.Commands.Delete;
using Application.Features.Author.Commands.Update;
using Application.Features.Author.Queries.GetAll;
using Application.Features.Author.Queries.GetById;
using Application.Features.Author.Queries.Single;
using Application.Features.AuthorImageFile.Commands.Remove;
using Application.Features.AuthorImageFile.Commands.Upload;
using Application.Features.AuthorImageFile.Queries.GetAuthorImages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> AddAuthor([FromBody]AddAuthorCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromQuery] UpdateAuthorCommandRequest request)
            => await NoDataResponse(request);

        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor([FromQuery] DeleteAuthorCommandRequest request)
            => await NoDataResponse(request);

        [HttpGet]
         public async Task<IActionResult> GetAllAuthors(GetAllAuthorQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdAuthor([FromQuery] GetByIdAuthorQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async Task<IActionResult> GetSingleOrDefaultAuthor([FromQuery] GetSingleAuthorQueryRequest request)
            => await DataResponse(request);


        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadAuthorImageFileCommandRequest request)
         => await NoDataResponse(request);

        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveAuthorImage([FromQuery] RemoveAuthorImageFileCommandRequest request)
            => await NoDataResponse(request);

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAuthorImages([FromQuery] GetAuthorImageFileRequest request)
            => await DataResponse(request);
    }
}
