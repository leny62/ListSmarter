using ListSmarter.Tasks.Dtos;
using Task = ListSmarter.Tasks.Repository.Models.Task;

namespace ListSmarter.Tasks.Business
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