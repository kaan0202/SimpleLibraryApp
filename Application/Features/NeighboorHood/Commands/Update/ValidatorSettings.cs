using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Update
{
    public class ValidatorSettings:AbstractValidator<UpdateNeighboorHoodCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.NeighboorHoodDto.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.NeighboorHoodDto.Name).NotEmpty();
        }
    }
}
