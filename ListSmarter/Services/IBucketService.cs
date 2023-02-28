using System.Collections.Generic;
using ListSmarter.Models;

namespace ListSmarter.Services
{
    public interface IBucketService
    {
        IEnumerable<BucketDto> GetAll();
        BucketDto GetById(int id);
        void CreateBucket(BucketDto bucketDto);
        void UpdateBucket(BucketDto bucketDto);
        void DeleteBucket(int id);
    }
}