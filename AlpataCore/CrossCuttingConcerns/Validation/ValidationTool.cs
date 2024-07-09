using FluentValidation;
using FluentValidation.Results;
using System;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            if (validator == null)
            {
                throw new ArgumentNullException(nameof(validator));
            }

            // Check if the entity is null
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            // Validate the entity
            ValidationResult result;
            if (entity is IValidationContext validationContext)
            {
                result = validator.Validate(validationContext);
            }
            else
            {
                // Create a new ValidationContext for the entity
                var context = new ValidationContext<object>(entity);
                result = validator.Validate(context);
            }

            // Check if the validation result is valid
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
