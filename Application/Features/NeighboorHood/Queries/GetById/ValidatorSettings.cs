using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NeighboorHood.Queries.GetById
{
    public class ValidatorSettings:AbstractValidator<GetByIdNeighboorHoodQueryRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
        }
    }
}
