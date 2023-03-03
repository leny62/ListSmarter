using System.Collections.Generic;
using ListSmarter.Models;

namespace ListSmarter.Services
{
    public interface IBucketService
    {
        IList<BucketDto> GetAll();
        BucketDto GetById(int id);
        BucketDto CreateBucket(BucketDto bucketDto);
        BucketDto UpdateBucket(int id, BucketDto bucketDto);
        BucketDto DeleteBucket(int id);
    }
}