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
            RuleFor(x=>x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x =>x.Surname).NotEmpty().NotNull();
            RuleFor(x =>x.BirthDay).NotEmpty().NotNull();
        }
    }
}
