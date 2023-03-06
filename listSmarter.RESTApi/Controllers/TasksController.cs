using FluentValidation;
using ListSmarter.Models;
using ListSmarter.Services;
using Microsoft.AspNetCore.Mvc;

namespace listSmarter.RESTApi.Controllers;


[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private ITaskService _taskService;
    
    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    // Get all Tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetAll()
    {
        return await Task.FromResult(Ok(_taskService.GetAll().ToList()));
    }
    
    // Get a Task by ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try 
        {
            return await Task.FromResult(Ok(_taskService.GetTaskById(id)));
        }
        catch (KeyNotFoundException)
        {
            return StatusCode(404, "Task with ID " + id + " not found");
        }
    }
    
    // Create a Task
    [HttpPost]
    public async Task<ActionResult<TaskDto>> CreateTask(TaskDto taskDto)
    {
        try 
        {
            TaskDto task = _taskService.CreateTask(taskDto);
            return await Task.FromResult(CreatedAtAction(nameof(GetById), new { id = task.Id }, task));
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    // Update a Task
    [HttpPut]
    public async Task<IActionResult> UpdateTask([FromRoute] int id, [FromBody] TaskDto taskDto)
    {
        try 
        {
            _taskService.UpdateTask(id, taskDto);
            return await Task.FromResult(Ok());
        }
        catch (KeyNotFoundException)
        {
            return StatusCode(404, "Task with ID " + id + " not found");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    // Delete a Task
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        try 
        {
            _taskService.DeleteTask(id);
            return await Task.FromResult(Ok());
        }
        catch (KeyNotFoundException)
        {
            return StatusCode(404, "Task with ID " + id + " not found");
        }
    }
    
    // Assign a Task to a Person
    [HttpPost("{taskId}/assignToPerson/{personId}")]
    public async Task<IActionResult> AssignTaskToPerson(int taskId, int personId)
    {
        try 
        {
            _taskService.AssignTaskToPerson(taskId, personId);
            return await Task.FromResult(Ok());
        }
        catch (KeyNotFoundException)
        {
            return StatusCode(404, "Task with ID " + taskId + " not found");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    // Assign a Task to a Bucket
    [HttpPost("{taskId}/assignToBucket/{bucketId}")]
    public async Task<IActionResult> AssignTaskToBucket(int taskId, int bucketId)
    {
        try 
        {
            _taskService.AssignTaskToBucket(taskId, bucketId);
            return await Task.FromResult(Ok());
        }
        catch (KeyNotFoundException)
        {
            return StatusCode(404, "Task with ID " + taskId + " not found");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    // Change the status of a Task
    [HttpPost("{taskId}/changeStatus/{status}")]
    public async Task<IActionResult> ChangeTaskStatus(int taskId, string taskStatus)
    {
        try 
        {
            _taskService.ChangeTaskStatus(taskId, taskStatus);
            return await Task.FromResult(Ok());
        }
        catch (KeyNotFoundException)
        {
            return StatusCode(404, "Task with ID " + taskId + " not found");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
}