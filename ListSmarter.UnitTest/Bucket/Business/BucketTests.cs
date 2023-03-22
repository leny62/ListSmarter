using System.Data;

namespace ListSmarter.UnitTest.Bucket.Business;

public class BucketsTests
{
    private readonly Mock<IBucketService> _bucketServiceMock;
    private readonly Mock<IValidator<BucketDto>> _bucketValidatorMock;
    
    
    public BucketsTests()
    {
        _bucketServiceMock = new Mock<IBucketService>();
        _bucketValidatorMock = new Mock<IValidator<BucketDto>>();
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
        _bucketServiceMock.Setup(x => x.GetAll()).Returns(buckets);
        
        // Act
        var result = _bucketServiceMock.Object.GetAll();
        
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
        _bucketServiceMock.Setup(x => x.GetById(1)).Returns(bucket);
        
        // Act
        var result = _bucketServiceMock.Object.GetById(1);
        
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
        _bucketServiceMock.Setup(x => x.Create(bucket)).Returns(bucket);
        
        // Act
        var result = _bucketServiceMock.Object.Create(bucket);
        
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
        _bucketServiceMock.Setup(x => x.Update(1, bucket)).Returns(bucket);
        
        // Act
        var result = _bucketServiceMock.Object.Update(1, bucket);
        
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
        _bucketServiceMock.Setup(x => x.Delete(1)).Returns(bucket);
        
        // Act
        var result = _bucketServiceMock.Object.Delete(1);
        
        // Assert
        result.Should().BeEquivalentTo(bucket);
    }
    
    [Fact]
    public void Create_DuplicateBucket_ShouldThrowException()
    {
        // Arrange
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 78",
        };
        _bucketServiceMock.Setup(x => x.Create(bucket)).Throws(new DuplicateNameException($"Bucket with title {bucket.Title} already exists"));
        
        // Act and Assert
        Assert.Throws<DuplicateNameException>(() => _bucketServiceMock.Object.Create(bucket));
    }
    
    [Fact]
    public void Update_DuplicateBucket_ShouldThrowException()
    {
        // Arrange
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 78",
        };
        _bucketServiceMock.Setup(x => x.Update(1, bucket)).Throws(new DuplicateNameException($"Bucket with title {bucket.Title} already exists"));
        
        // Act and Assert
        Assert.Throws<DuplicateNameException>(() => _bucketServiceMock.Object.Update(1, bucket));
    }
    
    [Fact]
    public void Create_InvalidBucket_ShouldThrowException()
    {
        // Arrange
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 78",
        };
        _bucketServiceMock.Setup(x => x.Create(bucket)).Throws(new ValidationException("Bucket is invalid"));
        
        // Act and Assert
        Assert.Throws<ValidationException>(() => _bucketServiceMock.Object.Create(bucket));
    }
    
    [Fact]
    public void Update_InvalidBucket_ShouldThrowException()
    {
        // Arrange
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 78",
        };
        _bucketServiceMock.Setup(x => x.Update(1, bucket)).Throws(new ValidationException("Bucket is invalid"));
        
        // Act and Assert
        Assert.Throws<ValidationException>(() => _bucketServiceMock.Object.Update(1, bucket));
    }
    
    [Fact]
    public void Delete_InvalidBucket_ShouldThrowException()
    {
        // Arrange
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 78",
        };
        _bucketServiceMock.Setup(x => x.Delete(1)).Throws(new ValidationException("Bucket is invalid"));
        
        // Act and Assert
        Assert.Throws<ValidationException>(() => _bucketServiceMock.Object.Delete(1));
    }
    
    // When a task is assigned to a bucket, that task should be added to the bucket
    [Fact]
    public void AssignTaskToBucket_ShouldAddTaskToBucket()
    {
        // Arrange
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 1",
        };
        var task = new TaskDto
        {
            Id = 1,
            Title = "Task 1",
        };
        
    }
}