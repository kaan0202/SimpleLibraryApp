using Application.Abstraction.Services;
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
        readonly IUserService _userService;
        readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _userService.CreateUser(new()
            {
              
                Email = request.Email,
                NameSurname = request.NameSurname,
                UserName = request.Username,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,

                

            });

            if (result.Success)
            {
                await _unitOfWork.SaveChangesAsync();
                return new SuccessWithNoDataResponse("Kullanıcı oluşturuldu");
            }
            
            throw new Exception("Hata");
        }
    }
}
