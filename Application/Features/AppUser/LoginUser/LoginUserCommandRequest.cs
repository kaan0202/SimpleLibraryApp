using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUser.LoginUser
{
    public class LoginUserCommandRequest:IRequest<BaseDataResponse<DTOs.TokenDto.Token>>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
