using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoMapper;
using ListSmarter.Common;
using ListSmarter.DTOs;
using ListSmarter.Repositories.Models;
using ListSmarter.Services.Interfaces;
using static ListSmarter.DTOs.BucketDto;

namespace ListSmarter.Repositories
{
    public class BucketRepository : IBucketRepository
    {
        private readonly IMapper _mapper;
        private readonly List<Bucket> _buckets;

        public BucketRepository(IMapper mapper)
        {
            _mapper = mapper;
            _buckets = TemporaryDatabase.Buckets;
        }

        public IList<BucketDto> GetAll()
        {
            return _mapper.Map<IList<BucketDto>>(_buckets);
        }
        
        public BucketDto GetById(int id)
        {
            Bucket bucket = _buckets.FirstOrDefault(b => b.Id == id);
            if (bucket == null)
            {
                return null;
            }
            return _mapper.Map<BucketDto>(bucket);
        }

        public BucketDto Create(Bucket bucket)
        {
            bucket.Id = _buckets.Any() ? _buckets.Max(b => b.Id) + 1 : 1;
            _buckets.Add(bucket);
            return _mapper.Map<BucketDto>(bucket);
        }
        
        
        public BucketDto Create(BucketDto bucketDto)
        {
            var bucket = _mapper.Map<Bucket>(bucketDto);
            bucket.Id = _buckets.Any() ? _buckets.Max(b => b.Id) + 1 : 1;
            _buckets.Add(bucket);
            return _mapper.Map<BucketDto>(bucket);
        }

        public BucketDto Update(int id, BucketDto bucketDto)
        {
            var bucketToUpdate = _buckets.FirstOrDefault(b => b.Id == bucketDto.Id);
            if (bucketToUpdate == null)
            {
                return null;
            }
            _mapper.Map(bucketDto, bucketToUpdate);
            return _mapper.Map<BucketDto>(bucketToUpdate);
        }

        public BucketDto Delete(int id)
        {
            Bucket bucketToRemove = _buckets.FirstOrDefault(b => b.Id == id);
            if (bucketToRemove == null)
            {
                return null;
            }
            _buckets.Remove(bucketToRemove);
            return _mapper.Map<BucketDto>(bucketToRemove);
        }
    }
}