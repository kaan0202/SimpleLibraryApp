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
            RuleFor(x => x.Person.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Person.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Person.Surname).NotEmpty().MaximumLength(65).NotEqual(x => x.Person.Name);
            RuleFor(x => x.Person.Name).NotEmpty().MaximumLength(35).NotEqual(x => x.Person.Surname);
            RuleFor(x => x.Person.BirthDay).NotEmpty();
            
        }
    }
}
