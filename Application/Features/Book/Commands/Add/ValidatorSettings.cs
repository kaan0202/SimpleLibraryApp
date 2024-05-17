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
            RuleFor(x => x.BookDto.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BookDto.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.BookDto.CatalogId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BookDto.PageOfNumber).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BookDto.LanguageId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BookDto.AuthorId).NotEmpty().GreaterThan(0);
            
        }
    }
}
