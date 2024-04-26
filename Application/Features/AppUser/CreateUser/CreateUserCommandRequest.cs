using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUser.CreateUser
{
    public class CreateUserCommandRequest:IRequest<BaseResponse>
    {
        public string NameSurname { get; set; }
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}
