using ListSmarter.Tasks.Dtos;
using Task = ListSmarter.Tasks.Repository.Models.Task;

namespace ListSmarter.Tasks.Business
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