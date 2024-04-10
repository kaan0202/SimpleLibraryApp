using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Address.Commands.Delete
{
    public class ValidatorSettings:AbstractValidator<DeleteAddressCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x=>x.Id).NotEmpty().GreaterThan(0);
        }
    }
}
