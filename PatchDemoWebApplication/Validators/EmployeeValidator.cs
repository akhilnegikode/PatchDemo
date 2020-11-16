using FluentValidation;
using PatchDemoWebApplication.Context;

namespace PatchDemoWebApplication.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(model => model.Salary).GreaterThan(10000).WithMessage("Salary should be greater than 10000");
            RuleFor(model => model.Salary).LessThan(50000).WithMessage("Salary should be less than 50000");
        }
    }
}
