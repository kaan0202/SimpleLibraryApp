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
            RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty().NotEqual(x=>x.Surname);
            RuleFor(x=>x.Salary).NotEmpty().GreaterThan(0);
            RuleFor(x => x.Surname).NotEmpty().NotEqual(x=>x.Name);
            RuleFor(x => x.Gender).NotEmpty();

            //1.30  

            //5.30
        }
    }
}
