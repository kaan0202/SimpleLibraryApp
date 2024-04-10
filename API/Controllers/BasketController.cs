using API.Controllers.Common;
using Application.Features.Basket.Commands.Add;
using Application.Features.Basket.Commands.Update;
using Application.Features.Basket.Queries.GetById;
using Application.Features.Basket.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class BasketController : BaseController
    {
        public BasketController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async void AddBasket([FromBody] AddBasketCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async void UpdateBasket([FromQuery] UpdateBasketCommandRequest request)
            => await NoDataResponse(request);

       
      

        [HttpGet("GetById")]
        public async void GetByIdBasket([FromQuery] GetByIdBasketQueryRequest request)
           => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")]
        public async void GetSingleOrDefaultBasket([FromQuery] GetSingleBasketQueryRequest request)
            => await DataResponse(request);
    }
}
