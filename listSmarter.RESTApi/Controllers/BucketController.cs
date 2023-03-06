using FluentValidation;
using ListSmarter.Models;
using ListSmarter.Services;
using Microsoft.AspNetCore.Mvc;

namespace listSmarter.RESTApi.Controllers
{
    [Route("api/v1/buckets")]
    public class BucketController : ControllerBase
    {
        private IBucketService _bucketService;
        
        public BucketController(IBucketService bucketService)
        {
            _bucketService = bucketService;
        }
        
        // Get all Buckets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BucketDto>>> GetAll()
        {
            return await Task.FromResult(Ok(_bucketService.GetAll().ToList()));
        }
        
        // Get a Bucket by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try 
            {
                return await Task.FromResult(Ok(_bucketService.GetById(id)));
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, "Bucket with ID " + id + " not found");
            }
        }
        
        // Create a Bucket
        [HttpPost]
        public async Task<ActionResult<BucketDto>> CreateBucket(BucketDto bucketDto)
        {
            try 
            {
                BucketDto bucket = _bucketService.CreateBucket(bucketDto);
                return await Task.FromResult(CreatedAtAction(nameof(GetById), new { id = bucket.Id }, bucket));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // Update a Bucket
        [HttpPut]
        public async Task<IActionResult> UpdateBucket(int id, [FromBody] BucketDto bucketDto)
        {
            try 
            {
                _bucketService.UpdateBucket(id, bucketDto);
                return await Task.FromResult(Ok());
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, "Bucket with ID " + id + " not found");
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // Delete a Bucket
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBucket(int id)
        {
            try 
            {
                _bucketService.DeleteBucket(id);
                return await Task.FromResult(Ok());
            }
            catch (KeyNotFoundException)
            {
                return StatusCode(404, "Bucket with ID " + id + " not found");
            }
        }
    }
}

