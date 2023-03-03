using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;


namespace ListSmarter.Models.Validators
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