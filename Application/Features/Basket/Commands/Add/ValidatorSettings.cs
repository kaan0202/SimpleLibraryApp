using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Commands.Add
{
    public class ValidatorSettings:AbstractValidator<AddBasketCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x=>x.Basket.Id).NotEmpty().GreaterThan(0);
            RuleFor(x=>x.Basket.PersonId).NotEmpty().GreaterThan(0);

        }
    }
}
