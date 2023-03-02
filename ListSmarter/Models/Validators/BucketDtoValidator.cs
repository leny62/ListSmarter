using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;


namespace ListSmarter.Models.Validators
{
    public class BucketDtoValidator : IValidator<BucketDto>
    {
        // create Validate method
        public static bool Validate(BucketDto bucketDto)
        {
            // check if bucketDto is null
            if (bucketDto == null)
            {
                // return false
                return false;
            }

            // check if bucketDto.Title is null or empty
            if (string.IsNullOrEmpty(bucketDto.Title))
            {
                // return false
                return false;
            }

            // return true
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

        ValidationResult IValidator<BucketDto>.Validate(BucketDto instance)
        {
            throw new NotImplementedException();
        }

        public Task<ValidationResult> ValidateAsync(BucketDto instance, CancellationToken cancellation = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}