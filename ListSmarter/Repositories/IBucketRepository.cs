using System.Collections.Generic;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public interface IBucketRepository
    {
        IEnumerable<Bucket> GetAll();
        BucketDto GetById(int id);
        void Create(Bucket bucket);
        void Update(BucketDto bucket);
        void Delete(BucketDto bucket);
        void IsNameUnique(Bucket bucket);
        int GetNextId();
    }
}