using System.Collections.Generic;
using ListSmarter.Enums;
using ListSmarter.Models;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Services
{
    public interface ITaskService
    {
        TaskDto GetTaskById(int id);
        IEnumerable<TaskDto> GetTasksByBucketId(int bucketId);
        IEnumerable<TaskDto> GetTasksByBucketIdAndStatus(int bucketId, string status);
        TaskDto CreateTask(TaskDto taskDto);
        void UpdateTask(TaskDto taskDto);
        void DeleteTask(Task id);
        void AssignUserToTask(int userId, int taskId);
        void UpdateTaskStatus(int taskId, Status status);
    }
}