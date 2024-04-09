using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Commands.Update
{
    public class ValidatorSettings:AbstractValidator<UpdateBookCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x=>x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x =>x.AuthorId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x=>x.CatalogId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x=>x.BasketId).GreaterThan(0);
            RuleFor(x=>x.LanguageId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x=>x.PageOfNumber).NotEmpty().NotNull().GreaterThan(0);
        }

    }
}
