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
            RuleFor(x => x.BookDto.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BookDto.AuthorId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BookDto.CatalogId).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.BookDto.BasketId).GreaterThan(0);
            RuleFor(x => x.BookDto.LanguageId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.BookDto.Name).NotNull().NotEmpty();
            RuleFor(x=>x.BookDto.PageOfNumber).NotEmpty().GreaterThan(0);
        }

    }
}
