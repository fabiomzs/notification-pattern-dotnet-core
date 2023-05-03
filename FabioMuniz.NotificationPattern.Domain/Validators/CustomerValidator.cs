using FabioMuniz.NotificationPattern.Domain.Entities;
using FluentValidation;

namespace FabioMuniz.NotificationPattern.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.Age).GreaterThan(15);
        }
    }
}
