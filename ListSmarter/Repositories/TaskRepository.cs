using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ListSmarter.Enums;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;
using Task = ListSmarter.Repositories.Models.Task;
using ListSmarter.Common;
using Microsoft.Extensions.DependencyInjection;
using TaskModel = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;
        private List<Task> _tasks;
        private List<Bucket> _buckets;
        private List<Person> _people;

        public TaskRepository(IMapper mapper)
        {
            _mapper = mapper;
            _tasks = TemporaryDatabase.Tasks;
            _buckets = TemporaryDatabase.Buckets;
            _people = TemporaryDatabase.People;
        }

        public IList<TaskDto> GetAll()
        {
            return _mapper.Map<IList<TaskDto>>(_tasks);
        }
        

       // add GetById method
        public TaskDto GetById(int id)
        {
            Task task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return null;
            }
            return _mapper.Map<TaskDto>(task);
        }

        public TaskDto Create(TaskDto task)
        {
            Task taskToCreate = _mapper.Map<Task>(task);
            taskToCreate.Id = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(taskToCreate);
            return _mapper.Map<TaskDto>(taskToCreate);
        }

        public TaskDto Update(int id, TaskDto task)
        {
            var taskToUpdate = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (taskToUpdate == null)
            {
                return null;
            }
            taskToUpdate.Title = task.Title;
            taskToUpdate.Description = task.Description;
            taskToUpdate.Status = task.Status;
            
            var assignee = _people.FirstOrDefault(person => person.Id == taskToUpdate?.Assignee?.Id);
            if (assignee != null)
            {
                taskToUpdate.Assignee = assignee;
                assignee.Tasks.Add(taskToUpdate);
            }
            
            var bucket = _buckets.FirstOrDefault(b => b.Id == taskToUpdate?.Bucket?.Id);
            if (bucket != null)
            {
                taskToUpdate.Bucket = bucket;
                bucket.Tasks.Add(taskToUpdate);
            }
            
            return _mapper.Map<TaskDto>(taskToUpdate);
        }
        
        public TaskDto AssignTaskToPerson(int taskId, int personId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                return null;
            }
            var person = _people.FirstOrDefault(p => p.Id == personId);
            if (person == null)
            {
                return null;
            }
            if (task.Assignee != null)
            {
                // Add to list of tasks
                task.Assignee.Tasks.Add(task);
            }

            task.Assignee = person;
            person.Tasks.Add(task);
            return _mapper.Map<TaskDto>(task);
        }
        
        public TaskDto AssignTaskToBucket(int taskId, int bucketId)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                return null;
            }
            var bucket = _buckets.FirstOrDefault(b => b.Id == bucketId);
            if (bucket == null)
            {
                return null;
            }
            if (task.Bucket != null)
            {
                // Add to list of tasks
                task.Bucket.Tasks.Add(task);
            }
            task.Bucket = bucket;
            bucket.Tasks.Add(task);
            return _mapper.Map<TaskDto>(task);
        }
        
        public TaskDto ChangeTaskStatus(int taskId, string status)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
            {
                return null;
            }
            // get the enum value from the string
            Status newStatus = (Status) System.Enum.Parse(typeof(Status), status);
            task.Status = newStatus.ToString();
            return _mapper.Map<TaskDto>(task);
        }
        
        public TaskDto Delete(int id)
        {
            Task task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return null;
            }
            _tasks.Remove(task);
            return _mapper.Map<TaskDto>(task);
        }

    }
}
