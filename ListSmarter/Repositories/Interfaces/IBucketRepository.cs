using System.Collections.Generic;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public interface IBucketRepository
    {
        IList<BucketDto> GetAll();
        BucketDto GetById(int id);
        BucketDto Create(BucketDto bucket);
        BucketDto Update(int id, BucketDto bucket);
        BucketDto Delete(int bucket);
    }
}