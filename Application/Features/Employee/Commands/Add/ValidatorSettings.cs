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
            RuleFor(x=>x.EmployeeDto.Id).NotEmpty().GreaterThan(0);
            RuleFor(x => x.EmployeeDto.Name).NotEmpty().NotEqual(x => x.EmployeeDto.Surname).NotEqual(x => x.EmployeeDto.Gender).MaximumLength(35);
            RuleFor(x => x.EmployeeDto.Surname).NotEmpty().NotEqual(x => x.EmployeeDto.Name).NotEqual(x => x.EmployeeDto.Gender).MaximumLength(50);
            RuleFor(x => x.EmployeeDto.Gender).NotEmpty().NotEqual(x => x.EmployeeDto.Surname).NotEqual(x => x.EmployeeDto.Name).MaximumLength(60);
        }
    }
}
