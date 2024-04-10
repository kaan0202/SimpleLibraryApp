using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Employee.Commands.Add
{
    public class ValidatorSettings:AbstractValidator<AddEmployeeCommandRequest>
    {
        public ValidatorSettings()
        {
            RuleFor(x=>x.Employee.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Employee.Name).NotEmpty().NotEqual(x => x.Employee.Surname).NotEqual(x => x.Employee.Gender).MaximumLength(35);
            RuleFor(x => x.Employee.Surname).NotEmpty().NotEqual(x => x.Employee.Name).NotEqual(x => x.Employee.Gender).MaximumLength(50);
            RuleFor(x => x.Employee.Gender).NotEmpty().NotEqual(x => x.Employee.Surname).NotEqual(x => x.Employee.Name).MaximumLength(60);
        }
    }
}
