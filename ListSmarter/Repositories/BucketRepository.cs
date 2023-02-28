using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoMapper;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;
using static ListSmarter.Models.BucketDto;

namespace ListSmarter.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        private readonly IMapper _mapper;
        private readonly List<Bucket> _buckets = new List<Bucket>();
        private IBucketRepository _bucketRepositoryImplementation;

        public BucketRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<BucketDto> GetAll()
        {
            return _mapper.Map<IEnumerable<BucketDto>>(_buckets);
        }

        IEnumerable<Bucket> IBucketRepository.GetAll()
        {
            return _buckets;
        }

        public BucketDto GetById(int id)
        {
            var bucket = _buckets.FirstOrDefault(b => b.Id == id);
            return _mapper.Map<BucketDto>(bucket);
        }

        public void Create(Bucket bucket)
        {
            _buckets.Add(bucket);
        }
        
        public void Delete(BucketDto bucket)
        {
            var bucketToRemove = _buckets.FirstOrDefault(b => b.Id == bucket.Id);
            if (bucketToRemove != null)
            {
                _buckets.Remove(bucketToRemove);
            }
        }

        public void IsNameUnique(Bucket bucket)
        {
            var bucketWithSameName = _buckets.FirstOrDefault(b => b.Title == bucket.Title);
            if (bucketWithSameName != null)
            {
                throw new DuplicateNameException($"Bucket with name {bucket.Title} already exists");
            }
        }

        public int GetNextId()
        {
            var previousId = _buckets.Any() ? _buckets.Max(b => b.Id) : 0;
            return previousId + 1;
        }

        public BucketDto Create(BucketDto bucketDto)
        {
            var bucket = _mapper.Map<Bucket>(bucketDto);
            bucket.Id = _buckets.Any() ? _buckets.Max(b => b.Id) + 1 : 1;
            _buckets.Add(bucket);
            return _mapper.Map<BucketDto>(bucket);
        }

        public void Update(BucketDto bucketDto)
        {
            var bucketToUpdate = _buckets.FirstOrDefault(b => b.Id == bucketDto.Id);
            if (bucketToUpdate != null)
            {
                _mapper.Map(bucketDto, bucketToUpdate);
            }
        }

        public void Delete(int id)
        {
            var bucketToRemove = _buckets.FirstOrDefault(b => b.Id == id);
            if (bucketToRemove != null)
            {
                _buckets.Remove(bucketToRemove);
            }
        }

        public bool IsEmpty(int id)
        {
            var bucket = _buckets.FirstOrDefault(b => b.Id == id);
            return bucket != null && !bucket.Tasks.Any();
        }

        public bool IsNameUnique(string title)
        {
            return !_buckets.Any(b => b.Title == title);
        }
    }
}