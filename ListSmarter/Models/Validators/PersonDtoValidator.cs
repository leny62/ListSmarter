using FluentValidation;
using FluentValidation.Results;

namespace ListSmarter.Models.Validators
{
    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {
            RuleFor(person => person.Id).GreaterThan(0);
            RuleFor(person => person.FirstName).NotEmpty().WithMessage("Person first name cannot be empty");
            RuleFor(person => person.LastName).NotEmpty().WithMessage("Person last name cannot be empty");
        }
    }
}