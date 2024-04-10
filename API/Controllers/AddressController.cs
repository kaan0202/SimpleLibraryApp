using API.Controllers.Common;
using Application.Features.Address.Commands.Add;
using Application.Features.Address.Commands.Delete;
using Application.Features.Address.Commands.Update;
using Application.Features.Address.Queries.GetAll;
using Application.Features.Address.Queries.GetById;
using Application.Features.Address.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AddressController : BaseController
    {
        public AddressController(IMediator mediator) : base(mediator)
        {

        }

        [HttpPost]
        public async void AddAddress([FromBody] AddAddressCommandRequest request)
            => await NoDataResponse(request);

        [HttpPut]
        public async void UpdateAddress([FromQuery]UpdateAddressCommandRequest request)
            => await NoDataResponse(request);

        [HttpDelete]
        public async void DeleteAddress([FromQuery]DeleteAddressCommandRequest request)
            => await NoDataResponse(request);

        [HttpGet]
        public async void GetAllAddresses(GetAllAddressQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetById")]
        public async void GetByIdAddress([FromQuery]GetByIdAddressQueryRequest request)
            => await DataResponse(request);

        [HttpGet("GetSingleOrDefault")] 
        public async void GetSingleOrDefaultAddress([FromQuery]GetSingleAddressQueryRequest request)
            => await DataResponse(request);
    }
}
