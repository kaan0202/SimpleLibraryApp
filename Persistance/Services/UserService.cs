using Application.Abstraction.Services;
using Application.DTOs.CreateUserDto;
using Domain.Entities.Identity;
using Domain.Results;
using Domain.Results.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userService)
        {
            _userManager = userService;
        }

        public async Task<BaseResponse> CreateUser(CreateUser user)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = user.Email,
                NameSurname = user.NameSurname,
                UserName = user.UserName,

            }, user.Password);
          
            List<string> errors = new List<string>();
            if (result.Succeeded)
               return new SuccessWithNoDataResponse("Başarılı");
            else
            {
                
                foreach (var error in result.Errors)
                {
                     
                    errors.Add($"{error.Code} - {error.Description}");
                }
            }
            throw new Exception(errors.ToString());
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessToken, int refreshTokenLifeTime)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessToken.AddMinutes(refreshTokenLifeTime);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new Exception("hata");
        }
    }
}
