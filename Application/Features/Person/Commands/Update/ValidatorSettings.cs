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
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.AddressId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x=>x.Surname).NotEmpty().NotEqual(x=>x.Name);
            RuleFor(x=>x.Name).NotEmpty().NotEqual(x=>x.Surname);
            RuleFor(x=>x.BirthDay).NotEmpty();
        }
    }
}
