using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Update
{
    public class ValidatorSettings:AbstractValidator<UpdateAddressCommandRequest>
    {
        public ValidatorSettings()
        {

            RuleFor(x => x.Address.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Address.PhoneNumber).NotEmpty().NotNull().MaximumLength(10);
            RuleFor(x =>x.Address.PersonId).NotEmpty().NotNull().GreaterThan(0);
           RuleFor(x => x.Address.OpenAddress).NotEmpty().NotNull();
            RuleFor(x =>x.Address.Description).NotEmpty().NotNull();
            RuleFor(x =>x.Address.AddressTitle).NotEmpty().NotNull();


           
        }
    }
}
