using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.Add
{
    public class ValidatorSettings:AbstractValidator<AddCatalogCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.Catalog.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Catalog.CatalogName).NotEmpty().MaximumLength(65);
            RuleFor(x => x.Catalog.LanguageId).NotEmpty().GreaterThan(0);
        }
    }
}
