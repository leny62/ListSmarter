using System.Collections.Generic;
using ListSmarter.DTOs;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Services
{
    public interface ITaskService
    {
        TaskDto GetById(int id);
        TaskDto Create(TaskDto taskDto);
        TaskDto Update(int id, TaskDto task);
        TaskDto Delete(int id);
        IList<TaskDto> GetAll();
        TaskDto AssignTaskToPerson (int taskId, int personI);
        TaskDto AssignTaskToBucket(int taskId, int bucket);
        TaskDto ChangeTaskStatus (int taskId, string status);
    }
}