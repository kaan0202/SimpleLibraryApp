using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services.Authentication
{
    public interface IInternalAuthentication
    {
        Task<DTOs.TokenDto.Token> LoginAsync(string userNameOrEmail, string password, int accessTokenLifeTime);
        Task<DTOs.TokenDto.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
