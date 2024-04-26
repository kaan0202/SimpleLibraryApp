using Application.Abstraction.Services;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.RefreshTokenLogin.Commands
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, BaseDataResponse<DTOs.TokenDto.Token>>
    {
        readonly IAuthService _authService;
        public RefreshTokenLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<BaseDataResponse<DTOs.TokenDto.Token>> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            DTOs.TokenDto.Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken); 

            return new SuccessDataResponse<DTOs.TokenDto.Token>(token);
        }
    }
}

