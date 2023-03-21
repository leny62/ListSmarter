using ListSmarter.Buckets.Dtos;

namespace ListSmarter.Buckets.Business
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