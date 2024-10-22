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
    
    public class BookController : BaseController
    {
        public BookController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async Task<IActionResult> UpdateBook([FromQuery] UpdateBookCommandRequest request)
            => await NoDataResponse(request);

      

        [HttpGet]
        public async Task<IActionResult> GetAllBooks([FromQuery]GetAllBookQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdBook([FromQuery] GetByIdBookQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async Task<IActionResult> GetSingleOrDefaultBook([FromQuery] GetSingleBookQueryRequest request)
            => await DataResponse(request);

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadBookImageFileCommandRequest request)
        => await NoDataResponse(request);

        [HttpDelete("[action]")]
        public async void RemoveBookImage([FromQuery] RemoveBookImageFileCommandRequest request)
            => await NoDataResponse(request);


        [HttpGet("[action]")]
        public async Task<IActionResult> GetBookImages(GetBookImageFileRequest request)
            => await DataResponse(request); 

    }
}
