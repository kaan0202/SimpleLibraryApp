using Application.DTOs.TokenDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services.Authentication
{
    public interface IExternalAuthentication
    {
        Task<DTOs.TokenDto.Token> FacebookLoginAsync(string authToken, int tokenLifeTime);
        Task<DTOs.TokenDto.Token> GoogleLoginAsync(string idToken, int tokenLifeTime);
    }
}
