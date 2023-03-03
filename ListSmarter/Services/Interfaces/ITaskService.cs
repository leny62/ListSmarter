using System.Collections.Generic;
using ListSmarter.Enums;
using ListSmarter.Models;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Services
{
    public interface ITaskService
    {
        TaskDto GetTaskById(int id);
        TaskDto CreateTask(TaskDto taskDto);
        TaskDto UpdateTask(int id, TaskDto task);
        TaskDto DeleteTask(int id);
        IList<TaskDto> GetAll();
        TaskDto AssignTaskToPerson (int taskId, PersonDto person);
        TaskDto AssignTaskToBucket (int taskId, BucketDto bucket);
        TaskDto ChangeTaskStatus (int taskId, string status);
    }
}