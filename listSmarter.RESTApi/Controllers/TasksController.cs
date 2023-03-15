using FluentValidation;
using ListSmarter.DTOs;
using ListSmarter.Services;
using Microsoft.AspNetCore.Mvc;

namespace listSmarter.RESTApi.Controllers;

[Route("api/v1/tasks")]
[ApiController]
public class TasksController : ControllerBase
{
    private ITaskService _taskService;
    
    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetAll()
    {
        return await Task.FromResult(Ok(_taskService.GetAll().ToList()));
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try 
        {
            return await Task.FromResult(Ok(_taskService.GetById(id)));
        }
        catch (KeyNotFoundException)
        {
            return StatusCode(404, "Task with ID " + id + " not found");
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<TaskDto>> Create(TaskDto taskDto)
    {
        try 
        {
            TaskDto task = _taskService.Create(taskDto);
            return await Task.FromResult(CreatedAtAction(nameof(GetById), new { id = task.Id }, task));
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPut]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] TaskDto taskDto)
    {
        try 
        {
            _taskService.Update(id, taskDto);
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
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try 
        {
            _taskService.Delete(id);
            return await Task.FromResult(Ok());
        }
        catch (KeyNotFoundException)
        {
            return StatusCode(404, "Task with ID " + id + " not found");
        }
    }
    
    [HttpPost("{taskId}/assign-to-person")]
    public async Task<ActionResult> AssignTaskToPerson(int taskId, int personId)
    {
        try 
        {
            _taskService.AssignTaskToPerson(taskId, personId);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Task with ID {taskId} not found");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost("{taskId}/assign-to-bucket")]
    public async Task<ActionResult> AssignTaskToBucket(int taskId, int bucketId)
    {
        try
        {
            _taskService.AssignTaskToBucket(taskId, bucketId);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Task with ID {taskId} not found");
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("{taskId}/changeStatus")]
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