using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Commands.Add
{
    public class ValidatorSettings:AbstractValidator<AddAuthorCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.Author.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Author.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Author.Surname).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Author.BirthDay).NotEmpty();
        }
    }
}
