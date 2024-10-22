using Application.DTOs.TokenDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUser.RefreshTokenLogin
{
    public class Request:IRequest<BaseDataResponse<DTOs.TokenDto.Token>>
    {
        public string RefreshToken { get; set; }
    }
}
