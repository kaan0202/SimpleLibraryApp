using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Commands.Add
{
    public class ValidatorSettings:AbstractValidator<AddNeighboorHoodCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.CommandDto.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.CommandDto.Name).NotEmpty().MaximumLength(60);
            
        }
    }
}
