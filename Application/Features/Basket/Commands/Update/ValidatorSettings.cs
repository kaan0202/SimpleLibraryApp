using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Basket.Commands.Update
{
    public class ValidatorSettings:AbstractValidator<UpdateBasketCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x =>x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x=>x.PersonId).NotEmpty().GreaterThan(0);
            
        }
    }
}
