using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ListSmarter.Models.Validators
{
    public class BucketDtoValidator
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
    }
}