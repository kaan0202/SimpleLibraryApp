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
            RuleFor(x => x.PersonDto.Id).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.PersonDto.AddressId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PersonDto.Password).NotEmpty();
            RuleFor(x => x.PersonDto.Email).NotEmpty().EmailAddress();
            RuleFor(x=>x.PersonDto.Surname).NotEmpty().NotEqual(x=>x.PersonDto.Name);
            RuleFor(x=>x.PersonDto.Name).NotEmpty().NotEqual(x=>x.PersonDto.Surname);
            RuleFor(x=>x.PersonDto.BirthDay).NotEmpty();
        }
    }
}
