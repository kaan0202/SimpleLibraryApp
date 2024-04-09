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

            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull();
            RuleFor(x =>x.PersonId).NotEmpty().NotNull().GreaterThan(0);
           RuleFor(x => x.OpenAddress).NotEmpty().NotNull();
            RuleFor(x =>x.Description).NotEmpty().NotNull();
            RuleFor(x =>x.AddressTitle).NotEmpty().NotNull();


           
        }
    }
}
