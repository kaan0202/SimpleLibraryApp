using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Book.Commands.Add
{
    public class ValidatorSettings:AbstractValidator<AddBookCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.Book.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Book.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Book.CatalogId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Book.PageOfNumber).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Book.LanguageId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Book.AuthorId).NotEmpty().GreaterThan(0);
            
        }
    }
}
