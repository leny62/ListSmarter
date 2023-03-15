using ListSmarter.DTOs;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Services.Interfaces
{
    public interface ITaskRepository
    {
        IList<TaskDto> GetAllTasks();
        TaskDto GetTaskById(int id);
        TaskDto Create(TaskDto task);
        TaskDto Update(int id, TaskDto task);
        TaskDto Delete(int id);
    }
}