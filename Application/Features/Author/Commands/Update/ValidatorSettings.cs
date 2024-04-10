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
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().NotEqual(x =>x.Surname).Length(2,25);
            RuleFor(x => x.Surname).NotEmpty().NotEqual(x=>x.Name).Length(2,50);
            RuleFor(x => x.BirthDay).NotEmpty();
        }
    }
}
