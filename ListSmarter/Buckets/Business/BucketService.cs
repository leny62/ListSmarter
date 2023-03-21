using System.Data;
using FluentValidation;
using ListSmarter.Buckets.Dtos;

namespace ListSmarter.Buckets.Business
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository _bucketRepository;
        private readonly IValidator<BucketDto> _bucketValidator;

        public BucketService(IBucketRepository bucketRepository, IValidator<BucketDto> bucketValidator)
        {
            _bucketRepository = bucketRepository;
            _bucketValidator = bucketValidator ?? throw new ArgumentNullException(nameof(bucketValidator));
        }

        public IList<BucketDto> GetAll()
        {
            var buckets = _bucketRepository.GetAll();
            return buckets;
        }

        public BucketDto GetById(int id)
        {
            ValidateBucketId(id);
            return _bucketRepository.GetById(id);
        }

        public BucketDto Create(BucketDto bucketDto)
        {
            _bucketValidator.ValidateAndThrow(bucketDto);
            var titleTaken = _bucketRepository.GetAll().Any(b => b.Title == bucketDto.Title);
            if (titleTaken)
            {
                throw new DuplicateNameException($"Bucket with title {bucketDto.Title} already exists");
            }
            return _bucketRepository.Create(bucketDto);
        }

        public BucketDto Update(int id, BucketDto bucketDto)
        {
            ValidateBucketId(id);
            var titleTaken = _bucketRepository.GetAll().Any(b => b.Title == bucketDto.Title);
            if (titleTaken)
            {
                throw new DuplicateNameException($"Bucket with title {bucketDto.Title} already exists");
            }
            if (bucketDto == null)
            {
                throw new ArgumentNullException(nameof(bucketDto));
            }
            return _bucketRepository.Update(id, bucketDto);
        }

        public BucketDto Delete(int id)
        {
            ValidateBucketId(id);
            var bucket = _bucketRepository.GetById(id);
            if (bucket.Tasks.Count > 0)
            {
                throw new DataException($"Bucket {bucket.Title} has tasks and cannot be deleted");
            }
            return _bucketRepository.Delete(id);
        }
        
        private void ValidateBucketId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
        }
    }
}
