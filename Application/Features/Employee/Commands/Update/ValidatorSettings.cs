using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands.Update
{
    public class ValidatorSettings:AbstractValidator<UpdateEmployeeCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x=>x.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x=>x.Salary).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(x => x.Surname).NotNull().NotEmpty();
            RuleFor(x =>x.Gender).NotEmpty().NotNull();
        }
    }
}
