using FluentValidation;
using ListSmarter.Repositories.Models;
using ListSmarter.Services;
using ListSmarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ListSmarter.ConsoleUI.Controllers;

public class BucketController
{
    private IBucketService _bucketService;
    private ITaskService _taskService;
    private IValidator<BucketDto> _bucketValidator;
    private IValidator<TaskDto> _taskValidator;
    
    public BucketController(IBucketService bucketService, ITaskService taskService, IValidator<BucketDto> bucketValidator, IValidator<TaskDto> taskValidator)
    {
        _bucketService = bucketService;
        _taskService = taskService;
        _bucketValidator = bucketValidator;
        _taskValidator = taskValidator;
    }
    
    public void CreateBucket()
    {
        Console.WriteLine("Enter bucket name:");
        var title = Console.ReadLine();
        var bucket = new BucketDto
        {
            Id = _bucketService.GetAll().Max(b => b.Id) + 1,
            Title = title
        };
        _bucketValidator.ValidateAndThrow(bucket);
        _bucketService.CreateBucket(bucket);
    }
    
    // Get all buckets
    public void GetAllBuckets()
    {
        var buckets = _bucketService.GetAll();
        foreach (var bucket in buckets)
        {
            Console.WriteLine($"Id: {bucket.Id}, Title: {bucket.Title}");
        }
    }
    
    // Get Bucket by Id
    public void GetBucketById()
    {
        Console.WriteLine("Enter bucket id:");
        var id = int.Parse(Console.ReadLine());
        var bucket = _bucketService.GetById(id);
        Console.WriteLine($"Id: {bucket.Id}, Title: {bucket.Title}");
    }
    
    // Update bucket
    public void UpdateBucket()
    {
        Console.WriteLine("Enter bucket id:");
        var id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter new bucket title:");
        var title = Console.ReadLine();
        var bucket = new BucketDto
        {
            Id = id,
            Title = title
        };
        _bucketValidator.ValidateAndThrow(bucket);
        _bucketService.UpdateBucket(id, bucket);
    }
    
    // Delete bucket
    
    public void DeleteBucket()
    {
        Console.WriteLine("Enter bucket id:");
        var id = int.Parse(Console.ReadLine());
        _bucketService.DeleteBucket(id);
    }
    
}
    
