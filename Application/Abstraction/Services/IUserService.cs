using Application.DTOs.CreateUserDto;
using Domain.Entities.Identity;
using Domain.Results.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public interface IUserService
    {
        Task<BaseResponse> CreateUser(CreateUser user);
        Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessToken, int refreshTokenLifeTime);
    }
}
