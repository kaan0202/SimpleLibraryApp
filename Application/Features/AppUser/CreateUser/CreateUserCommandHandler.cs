using Application.UnitOfWork;
using Domain.Results;
using Domain.Results.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, BaseResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = request.Email,
                NameSurname = request.NameSurname,
                UserName = request.Username,
                
                

            },request.Password);

            if (result.Succeeded)
            {
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Kullanıcı oluşturuldu");
            }
            throw new Exception("Hata");
        }
    }
}
