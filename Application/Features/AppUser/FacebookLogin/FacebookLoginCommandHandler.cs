using Application.DTOs.Facebook;
using Application.DTOs.TokenDto;
using Application.Token;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Features.AppUser.FacebookLogin
{
    public class FacebookLoginCommandHandler : IRequestHandler<FacebookLoginCommandRequest, BaseDataResponse<DTOs.TokenDto.Token>>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly HttpClient _httpClient;

        public FacebookLoginCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, ITokenHandler tokenHandler, IHttpClientFactory httpClient)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _httpClient = httpClient.CreateClient();
        }

        public async Task<BaseDataResponse<DTOs.TokenDto.Token>> Handle(FacebookLoginCommandRequest request, CancellationToken cancellationToken)
        {
            string accessTokenResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id=1417604472453121&client_secret=a50313883cd721dddf8648d5a30f73cf&grant_type=client_credentials");
            var facebookAccessTokenResponse = JsonSerializer.Deserialize<DTOs.TokenDto.FacebookAccessTokenDto>(accessTokenResponse);

            string userAccessTokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token ={request.AuthToken}&access_token ={facebookAccessTokenResponse.AccessToken}");
            FacebookUserAccessTokenValidation facebookUserAccessTokenValidation = JsonSerializer.Deserialize<FacebookUserAccessTokenValidation>(userAccessTokenValidation);

            if (facebookUserAccessTokenValidation.Data.IsValid)
            {
                string userInfoResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={request.AuthToken}");
                FacebookUserInfoResponse facebookUserInfo = JsonSerializer.Deserialize<FacebookUserInfoResponse>(userInfoResponse);

                var info = new UserLoginInfo("FACEBOOK", facebookUserAccessTokenValidation.Data.UserId, "FACEBOOK");
                Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

                bool result = user != null;
                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(facebookUserInfo.Email);
                    if (user == null)
                    {
                        user = new()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Email = facebookUserInfo.Email,
                            UserName = facebookUserInfo.Email,
                            NameSurname = facebookUserInfo.Name

                        };
                        var identityResult = await _userManager.CreateAsync(user);
                        result = identityResult.Succeeded;
                    }
                }

                if (result)
                {
                    await _userManager.AddLoginAsync(user, info);
                    DTOs.TokenDto.Token token = _tokenHandler.CreateAccessToken(5, user);
                   return new SuccessDataResponse<DTOs.TokenDto.Token>(token);
                }
            }
            throw new Exception("Sen buradan geçemen");

        }
    }
}
