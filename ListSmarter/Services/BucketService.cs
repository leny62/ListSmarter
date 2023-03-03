using System;
using System.Collections.Generic;
using System.Data;
using AutoMapper;
using FluentValidation;
using ListSmarter.Models;
using ListSmarter.Repositories;
using ListSmarter.Repositories.Models;
using ListSmarter.Common;

namespace ListSmarter.Services
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

     

        public BucketDto CreateBucket(BucketDto bucketDto)
        {
            _bucketValidator.ValidateAndThrow(bucketDto);
            var titleTaken = _bucketRepository.GetAll().Any(b => b.Title == bucketDto.Title);
            if (titleTaken)
            {
                throw new DuplicateNameException($"Bucket with title {bucketDto.Title} already exists");
            }
            return _bucketRepository.Create(bucketDto);
        }

        public BucketDto UpdateBucket(int id, BucketDto bucketDto)
        {
            ValidateBucketId(id);
            if (bucketDto == null)
            {
                throw new ArgumentNullException(nameof(bucketDto));
            }
            return _bucketRepository.Update(id, bucketDto);
        }

        public BucketDto DeleteBucket(int id)
        {
            ValidateBucketId(id);
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
