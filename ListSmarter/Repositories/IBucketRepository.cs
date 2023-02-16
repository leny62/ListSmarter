using System.Collections.Generic;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public interface IBucketRepository
    {
        IEnumerable<Bucket> GetAll();
        Bucket GetById(int id);
        void Create(Bucket bucket);
        void Update(Bucket bucket);
        void Delete(Bucket bucket);
    }
}