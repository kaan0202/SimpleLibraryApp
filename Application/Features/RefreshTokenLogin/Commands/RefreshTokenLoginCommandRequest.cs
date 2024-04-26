using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RefreshTokenLogin.Commands
{
    public class RefreshTokenLoginCommandRequest:IRequest<BaseDataResponse<DTOs.TokenDto.Token>>
    {
        public string RefreshToken { get; set; }
    }
}
