using Application.DTOs.TokenDto;
using Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Token
{
    public interface ITokenHandler
    {
       public DTOs.TokenDto.Token CreateAccessToken(int minutes,AppUser user);
        string CreateRefreshToken();
    }
}
