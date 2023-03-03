using System.Collections.Generic;
using ListSmarter.Enums;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Repositories
{
    public interface ITaskRepository
    {
        IList<TaskDto> GetAll();
        TaskDto GetById(int id);
        TaskDto Create(TaskDto task);
        TaskDto Update(int id, TaskDto task);
        TaskDto Delete(int id);
    }
}