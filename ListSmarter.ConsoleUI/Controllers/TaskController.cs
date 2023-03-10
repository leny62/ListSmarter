using FluentValidation;
using ListSmarter.Repositories.Models;
using ListSmarter.Services;
using ListSmarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ListSmarter.Enums;

namespace ListSmarter.ConsoleUI.Controllers;

public class TaskController
{
    private ITaskService _taskService;
    public IBucketService _bucketService;
    public IPersonService _personService;
    
    public IValidator<TaskDto> _taskValidator;
    
    public TaskController(ITaskService taskService, IBucketService bucketService, IPersonService personService, IValidator<TaskDto> taskValidator)
    {
        _taskService = taskService;
        _bucketService = bucketService;
        _personService = personService;
        _taskValidator = taskValidator;
    }
    
    public void CreateTask()
    {
        Console.WriteLine("Enter task name:");
        var title = Console.ReadLine();
        Console.WriteLine("Enter task description:");
        var description = Console.ReadLine();
        Console.WriteLine("Enter task status:");
        var status = Console.ReadLine();
        Console.WriteLine("Enter task bucket id:");
        var bucketId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter task person id:");
        var personId = int.Parse(Console.ReadLine());
        var task = new TaskDto
        {
            Id = _taskService.GetAll().Max(t => t.Id) + 1,
            Title = title,
            Description = description,
            Status = (Status) System.Enum.Parse(typeof(Status), status)
        };
        _taskValidator.ValidateAndThrow(task);
        _taskService.CreateTask(task);
    }
    
    // Get all tasks
    public void GetAllTasks()
    {
        var tasks = _taskService.GetAll();
        foreach (var task in tasks)
        {
            Console.WriteLine($"Id: {task.Id}, Title: {task.Title}, Description: {task.Description}, Status: {task.Status}");
        }
    }
    
    // Get Task by Id
    public void GetTaskById()
    {
        Console.WriteLine("Enter task id:");
        var id = int.Parse(Console.ReadLine());
        var task = _taskService.GetTaskById(id);
        Console.WriteLine($"Id: {task.Id}, Title: {task.Title}, Description: {task.Description}, Status: {task.Status}");
    }
    
    // Update task
    public void UpdateTask()
    {
        Console.WriteLine("Enter task id:");
        var id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter task name:");
        var title = Console.ReadLine();
        Console.WriteLine("Enter task description:");
        var description = Console.ReadLine();
        Console.WriteLine("Enter task status:");
        var status = Console.ReadLine();
        Console.WriteLine("Enter task bucket id:");
        var bucketId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter task person id:");
        var personId = int.Parse(Console.ReadLine());
        var task = new TaskDto
        {
            Id = id,
            Title = title,
            Description = description,
            Status = (Status) System.Enum.Parse(typeof(Status), status)
        };
        _taskValidator.ValidateAndThrow(task);
        _taskService.UpdateTask(id, task);
    }
    
    // Delete task
    public void DeleteTask()
    {
        Console.WriteLine("Enter task id:");
        var id = int.Parse(Console.ReadLine());
        _taskService.DeleteTask(id);
    }
    
    // Assign task to person
    public void AssignTaskToPerson()
    {
        Console.WriteLine("Enter task id:");
        var taskId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter person id:");
        var personId = int.Parse(Console.ReadLine());
        _taskService.AssignTaskToPerson(taskId, personId);
    }
    
    // Assign task to bucket
    public void AssignTaskToBucket()
    {
        Console.WriteLine("Enter task id:");
        var taskId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter bucket id:");
        var bucketId = int.Parse(Console.ReadLine());
        _taskService.AssignTaskToBucket(taskId, bucketId);
    }
    
    // Change task status
    public void ChangeTaskStatus()
    {
        Console.WriteLine("Enter task id:");
        var taskId = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter task status:");
        var status = Console.ReadLine();
        _taskService.ChangeTaskStatus(taskId, status);
    }
    
    // Get all tasks by for person
    public void GetAllTasksForPerson()
    {
        Console.WriteLine("Enter person id:");
        var personId = int.Parse(Console.ReadLine());
        var tasks = _taskService.GetAll().Where(t => t.Assignee.Id == personId);
        foreach (var task in tasks)
        {
            Console.WriteLine($"Id: {task.Id}, Title: {task.Title}, Description: {task.Description}, Status: {task.Status}");
        }
    }
    
    // Get all tasks by for bucket
    public void GetAllTasksForBucket()
    {
        Console.WriteLine("Enter bucket id:");
        var bucketId = int.Parse(Console.ReadLine());
        var tasks = _taskService.GetAll().Where(t => t.Bucket.Id == bucketId);
        foreach (var task in tasks)
        {
            Console.WriteLine($"Id: {task.Id}, Title: {task.Title}, Description: {task.Description}, Status: {task.Status}");
        }
    }
}