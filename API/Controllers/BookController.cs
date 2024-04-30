using API.Controllers.Common;
using Application.Features.AuthorImageFile.Commands.Remove;
using Application.Features.AuthorImageFile.Commands.Upload;
using Application.Features.Book.Commands.Add;
using Application.Features.Book.Commands.Update;
using Application.Features.Book.Queries.GetAll;
using Application.Features.Book.Queries.GetById;
using Application.Features.Book.Queries.GetSingle;
using Application.Features.BookImageFile.Commands.Remove;
using Application.Features.BookImageFile.Commands.Upload;
using Application.Features.BookImageFile.Queries.GetBookImages;
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

        [HttpPost("[action]")]
        public async void Upload([FromQuery] UploadBookImageFileCommandRequest request)
        => await NoDataResponse(request);

        [HttpDelete("[action]")]
        public async void RemoveBookImage([FromQuery] RemoveBookImageFileCommandRequest request)
            => await NoDataResponse(request);


        [HttpGet("[action]")]
        public async void GetBookImages(GetBookImageFileRequest request)
            => await DataResponse(request); 

    }
}
