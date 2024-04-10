using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Language.Commands.Update
{
    public class ValidatorSettings:AbstractValidator<UpdateLanguageCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.CatalogId).NotEmpty().GreaterThan(0);
        }
    }
}
