using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Commands.Update
{
    public class ValidatorSettings:AbstractValidator<UpdateAuthorCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.AuthorDto.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.AuthorDto.Name).NotEmpty().NotEqual(x =>x.AuthorDto.Surname).Length(2,25);
            RuleFor(x => x.AuthorDto.Surname).NotEmpty().NotEqual(x=>x.AuthorDto.Name).Length(2,50);
            RuleFor(x => x.AuthorDto.BirthDay).NotEmpty();
        }
    }
}
