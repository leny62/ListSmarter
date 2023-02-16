using System.Collections.Generic;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<Task> GetAll();
        Task GetById(int id);
        void Create(Task task);
        void Update(Task task);
        void Delete(Task task);
    }
}