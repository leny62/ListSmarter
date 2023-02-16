using System.Collections.Generic;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public class InMemoryTaskRepository : ITaskRepository
    {
        private readonly List<Task> _tasks;

        public InMemoryTaskRepository()
        {
            _tasks = new List<Task>();
        }
        
        public IEnumerable<Task> GetAll()
        {
            return _tasks;
        }
        
        public Task GetById(int id)
        {
            throw new System.NotImplementedException();
        }
        
        public void Create(Task task)
        {
            throw new System.NotImplementedException();
        }
        
        public void Update(Task task)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Task task)
        {
            throw new System.NotImplementedException();
        }
    }
}