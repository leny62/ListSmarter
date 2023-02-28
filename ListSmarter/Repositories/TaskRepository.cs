using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ListSmarter.Enums;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;
using Task = ListSmarter.Repositories.Models.Task;
using ListSmarter.Common;
using TaskModel = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;
        public List<TaskModel> _tasks = TemporaryDatabase.Tasks;
        public List<Person> _people = TemporaryDatabase.People;
        public List<Bucket> _buckets = TemporaryDatabase.Buckets;

        public TaskRepository(IMapper mapper, PersonRepository personRepository)
        {
            _mapper = mapper;
        }

        public IEnumerable<Task> GetAll()
        {
            return _mapper.Map<IEnumerable<Task>>(_tasks);
        }
        

       // add GetById method
        public Task GetById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Create(Task task)
        {

            _tasks.Add(task);
        }

        public void Update(Task task)
        {
            var taskToUpdate = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (taskToUpdate != null)
            {
                _mapper.Map(task, taskToUpdate);
            }
        }

        public void Delete(Task task)
        {
            var taskToDelete = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (taskToDelete == null)
            {
                throw new KeyNotFoundException("Task not found");
            }
            else
            {
                _tasks.Remove(taskToDelete);
            }
        }
        
        public void Update(TaskDto taskDto)
        {
            var taskToUpdate = _tasks.FirstOrDefault(t => t.Id == taskDto.Id);
            if (taskToUpdate != null)
            {
                _mapper.Map(taskDto, taskToUpdate);
            }
        }

        public IEnumerable<TaskDto> GetByBucketId(int bucketId)
        {
            var tasksByBucketId = _tasks.Where(t => t.Id == bucketId);
            return _mapper.Map<IEnumerable<TaskDto>>(tasksByBucketId);
        }

        public object GetByBucketIdAndStatus(int bucketId, string status)
        {
            var statusEnum = (Status) Enum.Parse(typeof(Status), status, ignoreCase: true);
            var tasksByBucketIdAndStatus = _tasks.Where(t => t.Id == bucketId && t.Status == statusEnum);
            return _mapper.Map<IEnumerable<TaskDto>>(tasksByBucketIdAndStatus);
        }

        public void UpdateStatus(int taskId, string status)
        {
            throw new NotImplementedException();
        }

        public int GetNextId()
        {
            return _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
        }

        public IEnumerable<TaskDto> GetByStatus(TaskStatus status)
        {
            var tasksByStatus = _tasks.Where(t => (int)t.Status == (int)status);
            return _mapper.Map<IEnumerable<TaskDto>>(tasksByStatus);
        }

        public void AssignUserToTask(int userId, int taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {taskId} not found.");
            }

            var user = _people.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            }

            task.Assignee = user;
        }

        object ITaskRepository.GetByBucketId(int bucketId)
        {
            return GetByBucketId(bucketId);
        }

        public void UpdateTaskStatus(int taskId, Status status)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {taskId} not found.");
            }

            task.Status = status;
        }
    }
}
