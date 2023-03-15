using ListSmarter.DTOs;

namespace ListSmarter.Services.Interfaces
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