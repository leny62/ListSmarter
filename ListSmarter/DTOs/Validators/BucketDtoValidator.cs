using FluentValidation;

namespace ListSmarter.DTOs.Validators
{
    public class BucketDtoValidator : AbstractValidator<BucketDto>
    {
        public BucketDtoValidator()
        {
            RuleFor(bucket => bucket.Id).GreaterThan(0);
            RuleFor(bucket => bucket.Title).NotEmpty();
        }
    }
}