using FluentValidation;
using ListSmarter.Buckets.Dtos;

namespace ListSmarter.Buckets.Validators
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