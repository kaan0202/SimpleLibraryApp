using API.Controllers.Common;
using Application.Features.AppUser.CreateUser;
using Application.Features.AppUser.GoogleLogin;
using Application.Features.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class UserController : BaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost]
        public async void CreateUser([FromBody] CreateUserCommandRequest request)
            => await NoDataResponse(request);

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest request)
            => await NoDataResponse(request);

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest request)
            => await DataResponse(request);

        [HttpPost("facebook-login")]
        public async Task<IActionResult> FacebookLogin(GoogleLoginCommandRequest request)
           => await DataResponse(request);


    }
}
