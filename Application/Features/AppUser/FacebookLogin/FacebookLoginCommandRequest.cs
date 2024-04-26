using Application.DTOs.TokenDto;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUser.FacebookLogin
{
    public class FacebookLoginCommandRequest:IRequest<BaseDataResponse<DTOs.TokenDto.Token>>
    {
        public string AuthToken { get; set; }
    }
}
