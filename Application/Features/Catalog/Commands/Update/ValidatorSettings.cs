using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Catalog.Commands.Update
{
    public class ValidatorSettings:AbstractValidator<UpdateCatalogCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.CatalogDto.Id).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.CatalogDto.LanguageId).NotEmpty().GreaterThan(0);
        }
    }
}
