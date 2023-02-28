using System;
using System.Collections.Generic;
using AutoMapper;
using ListSmarter.Models;
using ListSmarter.Repositories;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Services
{
    public class BucketService : IBucketService
    {
        private readonly IMapper _mapper;
        private readonly IBucketRepository _bucketRepository;

        public BucketService(IMapper mapper, IBucketRepository bucketRepository)
        {
            _mapper = mapper;
            _bucketRepository = bucketRepository;
        }

        public IEnumerable<BucketDto> GetAll()
        {
            var buckets = _bucketRepository.GetAll();
            return _mapper.Map<IEnumerable<BucketDto>>(buckets);
        }

        public BucketDto GetById(int id)
        {
            var bucket = _bucketRepository.GetById(id);
            return _mapper.Map<BucketDto>(bucket);
        }

        public void CreateBucket(BucketDto bucketDto)
        {
            _bucketRepository.Create(_mapper.Map<Bucket>(bucketDto));
        }

        public void UpdateBucket(BucketDto bucketDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteBucket(int id)
        {
            throw new NotImplementedException();
        }

        public BucketDto Create(BucketDto bucketDto)
        {
            if (bucketDto == null)
            {
                throw new ArgumentNullException(nameof(bucketDto));
            }

            var bucket = _mapper.Map<Bucket>(bucketDto);
            bucket.Id = _bucketRepository.GetNextId();
            _bucketRepository.Create(bucket);
            return _mapper.Map<BucketDto>(bucket);
        }

        public void Update(BucketDto bucketDto)
        {
            if (bucketDto == null)
            {
                throw new ArgumentNullException(nameof(bucketDto));
            }

            var bucketToUpdate = _bucketRepository.GetById(bucketDto.Id);
            if (bucketToUpdate == null)
            {
                throw new ArgumentNullException(nameof(bucketDto));
            }

            _mapper.Map(bucketDto, bucketToUpdate);

            _bucketRepository.Update(bucketToUpdate);
        }

        public void Delete(int id)
        {
            var bucketToDelete = _bucketRepository.GetById(id);
            if (bucketToDelete == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            _bucketRepository.Delete(bucketToDelete);
        }
    }
}
