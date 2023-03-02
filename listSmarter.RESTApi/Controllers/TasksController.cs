using ListSmarter.Models;
using ListSmarter.Services;
using Microsoft.AspNetCore.Mvc;

namespace listSmarter.RESTApi.Controllers;


[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
   private readonly ILogger<TasksController> _logger;
   private readonly ITaskService _taskService;
   
   public TasksController(ILogger<TasksController> logger, ITaskService taskService)
   {
       _logger = logger;
       _taskService = taskService;
   }
   
   // Create a Task
    [HttpPost]
    public ActionResult<TaskDto> CreateTask(TaskDto taskDto)
    {
        var task = _taskService.CreateTask(taskDto);
        return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
    }
    
    // Get a Task by ID
    [HttpGet("{id}")]
    
    public IActionResult GetById(int id)
    {
        var task = _taskService.GetTaskById(id);
        if (task == null)
        {
            return NotFound("Task with ID " + id + " not found");
        }

        return Ok(task);
    }
    
    // Get all Tasks
    [HttpGet]
    public ActionResult<IEnumerable<TaskDto>> GetAll()
    {
        var tasks = _taskService.GetAll();
        return Ok(tasks);
    }
    
    // Get all Tasks by Bucket ID
    [HttpGet("bucket/{bucketId}")]
    public ActionResult<IEnumerable<TaskDto>> GetByBucketId(int bucketId)
    {
        var tasks = _taskService.GetTasksByBucketId(bucketId);
        return Ok(tasks);
    }
    
    // Update a Task
    [HttpPut]
    public ActionResult<TaskDto> UpdateTask(int id)
    {
        try
        {
           _taskService.UpdateTask(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return NoContent();
    }
    
    // Delete a Task
    [HttpDelete("{id}")]
    public ActionResult DeleteTask(int id)
    {
        try
        {
            _taskService.DeleteTask(id);
            return NoContent();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}