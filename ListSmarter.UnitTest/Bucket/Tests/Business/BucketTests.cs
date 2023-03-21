using System.Collections.Generic;
using FluentAssertions;
using FluentValidation;
using ListSmarter.Buckets.Business;
using ListSmarter.Buckets.Dtos;
using Moq;
using Xunit;

namespace ListSmarter.UnitTest.People.Tests.Business;

public class BucketsTests
{
    private readonly Mock<IBucketService> _personServiceMock;
    private readonly Mock<IValidator<BucketDto>> _personValidatorMock;
    
    
    public BucketsTests()
    {
        _personServiceMock = new Mock<IBucketService>();
        _personValidatorMock = new Mock<IValidator<BucketDto>>();
    }
    
    [Fact]
    public void GetAll_ShouldReturnAllBuckets()
    {
        // Arrange
        var buckets = new List<BucketDto>
        {
            new BucketDto
            {
                Id = 1,
                Title = "Bucket 1",
            },
            new BucketDto
            {
                Id = 2,
                Title = "Bucket 2",
            }
        };
        _personServiceMock.Setup(x => x.GetAll()).Returns(buckets);
        
        // Act
        var result = _personServiceMock.Object.GetAll();
        
        // Assert
        result.Should().BeEquivalentTo(buckets);
    }
    
    [Fact]
    public void GetById_ShouldReturnBucket()
    {
        // Arrange
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 1",
        };
        _personServiceMock.Setup(x => x.GetById(1)).Returns(bucket);
        
        // Act
        var result = _personServiceMock.Object.GetById(1);
        
        // Assert
        result.Should().BeEquivalentTo(bucket);
    }
    
    [Fact]
    public void Create_ShouldCreateBucket()
    {
        // Arrange
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 1",
        };
        _personServiceMock.Setup(x => x.Create(bucket)).Returns(bucket);
        
        // Act
        var result = _personServiceMock.Object.Create(bucket);
        
        // Assert
        result.Should().BeEquivalentTo(bucket);
    }
    
    [Fact]
    public void Update_ShouldUpdateBucket()
    {
        // Arrange
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 1",
        };
        _personServiceMock.Setup(x => x.Update(1, bucket)).Returns(bucket);
        
        // Act
        var result = _personServiceMock.Object.Update(1, bucket);
        
        // Assert
        result.Should().BeEquivalentTo(bucket);
    }
    
    [Fact]
    public void Delete_ShouldDeleteBucket()
    {
        // Arrange
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 1",
        };
        _personServiceMock.Setup(x => x.Delete(1)).Returns(bucket);
        
        // Act
        var result = _personServiceMock.Object.Delete(1);
        
        // Assert
        result.Should().BeEquivalentTo(bucket);
    }
    

}