using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Commands.Update
{
    public class ValidatorSettings:AbstractValidator<UpdatePersonCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x=>x.AddressId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x=>x.Surname).NotNull().NotEmpty();
            RuleFor(x=>x.Name).NotEmpty().NotNull();
            RuleFor(x=>x.BirthDay).NotEmpty();
        }
    }
}
