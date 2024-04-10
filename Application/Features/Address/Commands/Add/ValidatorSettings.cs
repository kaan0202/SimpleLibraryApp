using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Add
{
    public class ValidatorSettings:AbstractValidator<AddAddressCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.Address.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Address.Description).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Address.PhoneNumber).NotEmpty().Length(10);
            RuleFor(x => x.Address.OpenAddress).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Address.AddressTitle).NotEmpty().MaximumLength(20);
            
        }
    }
}
