using Application.Abstraction.Services;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUser.RefreshTokenLogin
{
    public class Handler : IRequestHandler<Request, BaseDataResponse<DTOs.TokenDto.Token>>
    {
        private readonly IAuthService _authService;

        public Handler(IAuthService authService)
        {
            _authService = authService;
        }

        
        public async Task<BaseDataResponse<DTOs.TokenDto.Token>> Handle(Request request, CancellationToken cancellationToken)
        {
           DTOs.TokenDto.Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
            if(token != null) 
             return new  SuccessDataResponse<DTOs.TokenDto.Token>(token);

            throw new Exception("Hata");

        }

       
    }
}
