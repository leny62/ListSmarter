using System.Collections.Generic;
using ListSmarter.DTOs;

namespace ListSmarter.Services
{
    public interface IBucketService
    {
        IList<BucketDto> GetAll();
        BucketDto GetById(int id);
        BucketDto Create(BucketDto bucketDto);
        BucketDto Update(int id, BucketDto bucketDto);
        BucketDto Delete(int id);
    }
}