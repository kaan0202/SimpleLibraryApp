using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Author.Commands.Delete
{
    public class ValidatorSettings:AbstractValidator<DeleteAuthorCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x=>x.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
