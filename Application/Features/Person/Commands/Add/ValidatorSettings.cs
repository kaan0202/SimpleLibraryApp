using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Person.Commands.Add
{
    public class ValidatorSettings:AbstractValidator<AddPersonCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.PersonDto.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PersonDto.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PersonDto.Surname).NotEmpty().MaximumLength(65).NotEqual(x => x.PersonDto.Name);
            RuleFor(x => x.PersonDto.Name).NotEmpty().MaximumLength(35).NotEqual(x => x.PersonDto.Surname);
            RuleFor(x => x.PersonDto.BirthDay).NotEmpty();
            
        }
    }
}
