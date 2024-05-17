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
            RuleFor(x => x.EmployeeDto.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EmployeeDto.Name).NotEmpty().NotEqual(x=>x.EmployeeDto.Surname);
            RuleFor(x=>x.EmployeeDto.Salary).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EmployeeDto.Surname).NotEmpty().NotEqual(x=>x.EmployeeDto.Name);
            RuleFor(x => x.EmployeeDto.Gender).NotEmpty();

            //1.30  

            //5.30
        }
    }
}
