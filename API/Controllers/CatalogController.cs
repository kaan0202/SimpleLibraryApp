using API.Controllers.Common;
using Application.Features.Catalog.Commands.Add;
using Application.Features.Catalog.Commands.Update;
using Application.Features.Catalog.Queries.GetAll;
using Application.Features.Catalog.Queries.GetById;
using Application.Features.Catalog.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class CatalogController : BaseController
    {
        public CatalogController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> AddCatalog([FromBody] AddCatalogCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async Task<IActionResult> UpdateCatalog([FromQuery] UpdateCatalogCommandRequest request)
            => await NoDataResponse(request);

        

        [HttpGet]
        public async Task<IActionResult> GetAllCatalogs(GetAllCatalogQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async Task<IActionResult> GetByIdCatalog([FromQuery] GetByIdCatalogQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async Task<IActionResult> GetSingleOrDefaultCatalog([FromQuery] GetSingleCatalogQueryRequest request)
            => await DataResponse(request);
    }
}
