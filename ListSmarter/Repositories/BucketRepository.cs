using System;
using System.Collections.Generic;
using System.Linq;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public class BucketRepository : IBucketRepository
    {

        private readonly List<Bucket> _buckets;

        public BucketRepository()
        {
            _buckets = new List<Bucket>();
        }

        public IEnumerable<Bucket> GetAll()
        {
            return _buckets;
        }

        public Bucket GetById(int id)
        {
            return _buckets.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Bucket bucket)
        {
            if (_buckets.Any(x => x.Title == bucket.Title))
            {
                throw new System.Exception("Bucket with this title already exists");
            }
            _buckets.Add(bucket);
        }

        public void Update(Bucket bucket)
        {
            var existingBucket = GetById(bucket.Id);
            
            if (existingBucket == null)
            {
                throw new System.Exception("Bucket does not exist");
            }
            
            if (_buckets.Any(x => x.Title == bucket.Title && x.Id != bucket.Id))
            {
                throw new System.Exception("Bucket with this title already exists");
            }
            
            existingBucket.Title = bucket.Title;
            
        }

        public void Delete(Bucket bucket)
        {
            if (bucket.Tasks.Any())
            {
                throw new ArgumentException("Bucket can not be removed if there are tasks assigned to it");
            }

            _buckets.Remove(bucket);
        }
    }
}