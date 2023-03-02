using FluentValidation;
using FluentValidation.Results;

namespace ListSmarter.Models.Validators
{
    public class PersonDtoValidator : IValidator<PersonDto>
    {
        public static bool Validate(PersonDto person)
        {
            if (person == null)
            {
                return false;
            }
            if (person.Id < 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(person.FirstName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(person.LastName))
            {
                return false;
            }
            if (person.Tasks == null)
            {
                return false;
            }
            return true;
        }

        public ValidationResult Validate(IValidationContext context)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(IValidationContext context, CancellationToken cancellation = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public IValidatorDescriptor CreateDescriptor()
        {
            throw new NotImplementedException();
        }

        public bool CanValidateInstancesOfType(Type type)
        {
            throw new NotImplementedException();
        }

        ValidationResult IValidator<PersonDto>.Validate(PersonDto instance)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(PersonDto instance, CancellationToken cancellation = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}