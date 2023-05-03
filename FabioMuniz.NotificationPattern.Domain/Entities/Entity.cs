using FluentValidation;
using FluentValidation.Results;

namespace FabioMuniz.NotificationPattern.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public ValidationResult ValidationResult { get; protected set; }

        public bool Validate<T>(T model, AbstractValidator<T> validator)
        {
            ValidationResult = validator.Validate(model);
            
            return ValidationResult.IsValid;
        }
    }
}
