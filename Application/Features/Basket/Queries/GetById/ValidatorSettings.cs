using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Queries.GetById
{
    public class ValidatorSettings:AbstractValidator<GetByIdBasketQueryRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
