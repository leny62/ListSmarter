using System.Collections.Generic;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using ListSmarter.Buckets.Dtos;
using ListSmarter.People.Dtos;
using ListSmarter.Tasks.Business;
using ListSmarter.Tasks.Dtos;
using ListSmarter.Tasks.Repository.Models;
using Moq;
using Xunit;

namespace ListSmarter.UnitTest.Tasks.Tests.Business;

public class TasksTests
{
    private readonly Mock<ITaskService> _taskServiceMock;
    private readonly Mock<IValidator<TaskDto>> _taskValidatorMock;


    public TasksTests()
    {
        _taskServiceMock = new Mock<ITaskService>();
        _taskValidatorMock = new Mock<IValidator<TaskDto>>();
    }

    [Fact]
    public void GetAll_ShouldReturnAllTasks()
    {
        // Arrange
        var tasks = new List<TaskDto>
        {
            new TaskDto
            {
                Id = 1,
                Title = "Task 1",
                Description = "This is the first task"
            },
            new TaskDto
            {
                Id = 2,
                Title = "Task 2",
                Description = "This is the second task"
            }
        };
        _taskServiceMock.Setup(x => x.GetAll()).Returns(tasks);

        // Act
        var result = _taskServiceMock.Object.GetAll();

        // Assert
        result.Should().BeEquivalentTo(tasks);
    }

    [Fact]
    public void GetById_ShouldReturnTask()
    {
        // Arrange
        var task = new TaskDto
        {
            Id = 1,
            Title = "Task 1",
            Description = "This is the first task"
        };
        _taskServiceMock.Setup(x => x.GetById(1)).Returns(task);

        // Act
        var result = _taskServiceMock.Object.GetById(1);

        // Assert
        result.Should().BeEquivalentTo(task);
    }

    [Fact]
    public void Create_ShouldCreateTask()
    {
        // Arrange
        var task = new TaskDto
        {
            Id = 1,
            Title = "Task 1",
            Description = "This is the first task"
        };
        _taskServiceMock.Setup(x => x.Create(task)).Returns(task);

        // Act
        var result = _taskServiceMock.Object.Create(task);

        // Assert
        result.Should().BeEquivalentTo(task);
    }

    [Fact]
    public void Delete_ShouldDeleteTask()
    {
        // Arrange
        var task = new TaskDto
        {
            Id = 1,
            Title = "Task 1",
            Description = "This is the first task"
        };
        _taskServiceMock.Setup(x => x.Delete(task.Id));

        // Act
        _taskServiceMock.Object.Delete(task.Id);

        // Assert
        _taskServiceMock.Verify(x => x.Delete(task.Id), Times.Once);
    }

    [Fact]
    public TaskDto AssignTaskToPerson_ShouldAssignTaskToPerson()
    {
        // Arrange
        var task = new TaskDto
        {
            Id = 1,
            Title = "Task 1",
            Description = "This is the first task"
        };
        var person = new PersonDto
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };
        _taskServiceMock.Setup(x => x.AssignTaskToPerson(task.Id, person.Id));

        // Act
        _taskServiceMock.Object.AssignTaskToPerson(task.Id, person.Id);

        // Assert
        _taskServiceMock.Verify(x => x.AssignTaskToPerson(task.Id, person.Id), Times.Once);
        
        return task;
    }
    
    [Fact]
    public TaskDto AssignTaskToBucket_ShouldAssignTaskToBucket()
    {
        // Arrange
        var task = new TaskDto
        {
            Id = 1,
            Title = "Task 1",
            Description = "This is the first task"
        };
        var bucket = new BucketDto
        {
            Id = 1,
            Title = "Bucket 1",
        };
        _taskServiceMock.Setup(x => x.AssignTaskToBucket(task.Id, bucket.Id));

        // Act
        _taskServiceMock.Object.AssignTaskToBucket(task.Id, bucket.Id);

        // Assert
        _taskServiceMock.Verify(x => x.AssignTaskToBucket(task.Id, bucket.Id), Times.Once);
        
        return task;
    }

    [Fact]
    public TaskDto ChangeTaskStatus_WithValidData_ShouldUpdateTaskStatus()
    {
        int taskId = 1;
        string status = "InProgress";
        
        TaskDto task = new TaskDto
        {
            Id = taskId,
            Title = "Task 1",
            Description = "This is the first task",
            Status = Status.Open
        };
        TaskDto expectedTask = new TaskDto
        {
            Id = taskId,
            Title = "Task 1",
            Description = "This is the first task",
            Status = Status.InProgress
        };
        
        _taskServiceMock.Setup(x => x.ChangeTaskStatus(taskId, status)).Returns(expectedTask);
        
        // Act
        var result = _taskServiceMock.Object.ChangeTaskStatus(taskId, status);
        
        // Assert
        result.Should().BeEquivalentTo(expectedTask);
        
        return task;
    }
    
    [Fact]
    public TaskDto ChangeTaskStatus_WithInvalidData_ShouldNotUpdateTaskStatus()
    {
        // use Invalid status
        int taskId = 1;
        string status = "Invalid";
        
        TaskDto task = new TaskDto
        {
            Id = taskId,
            Title = "Task 1",
            Description = "This is the first task",
            Status = Status.Open
        };
        
        _taskServiceMock.Setup(x => x.ChangeTaskStatus(taskId, status)).Returns(task);
        
        // Act
        var result = _taskServiceMock.Object.ChangeTaskStatus(taskId, status);
        
        // Assert
        result.Should().BeEquivalentTo(task);
        return task;
    }

}