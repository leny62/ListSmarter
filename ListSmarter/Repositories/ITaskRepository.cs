using System.Collections.Generic;
using ListSmarter.Enums;
using ListSmarter.Repositories.Models;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
        Task GetById(int id);
        void Create(Task task);
        void Update(Task task);
        void Delete(Task task);
        void AssignUserToTask(int userId, int taskId);
        object GetByBucketId(int bucketId);
        object GetByBucketIdAndStatus(int bucketId, string status);
        void UpdateStatus(int taskId, string status);
        int GetNextId();
        void UpdateTaskStatus(int taskId, Status status);
    }
}