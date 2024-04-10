using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.Add
{
    public class ValidatorSettings:AbstractValidator<AddLanguageCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x =>x.Language.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Language.Name).NotEmpty().MaximumLength(30);

        }
    }
}
