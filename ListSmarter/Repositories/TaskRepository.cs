using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ListSmarter.Repositories.Models;
using Task = ListSmarter.Repositories.Models.Task;
using ListSmarter.Common;
using ListSmarter.DTOs;
using ListSmarter.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TaskModel = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;
        private List<Task?> _tasks;
        private List<Bucket> _buckets;
        private List<Person?> _people;

        public TaskRepository(IMapper mapper)
        {
            _mapper = mapper;
            _tasks = TemporaryDatabase.Tasks;
            _buckets = TemporaryDatabase.Buckets;
            _people = TemporaryDatabase.People;
        }

        public IList<TaskDto> GetAllTasks()
        {
            return _mapper.Map<IList<TaskDto>>(_tasks);
        }
        

        public TaskDto GetTaskById(int id)
        {
            Task? task = _tasks.FirstOrDefault(t => t!.Id == id);
            if (task == null)
            {
                return null;
            }
            return _mapper.Map<TaskDto>(task);
        }

        public TaskDto Create(TaskDto task)
        {
            Task? taskToCreate = _mapper.Map<Task>(task);
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

            if (task.Assignee.HasValue)
            {
                taskToUpdate.Assignee = (int)task.Assignee;
                Person? person = _people.FirstOrDefault(p => p.Id == task.Assignee);
                if (person != null)
                {
                    person.Tasks.Add(taskToUpdate);
                }
            }
            
            if (task.Bucket.HasValue)
            {
                taskToUpdate.Bucket = (int)task.Bucket;
                Bucket? bucket = _buckets.FirstOrDefault(b => b.Id == task.Bucket);
                if (bucket != null)
                {
                    bucket.Tasks.Add(taskToUpdate);
                }
            }

            return _mapper.Map<TaskDto>(taskToUpdate);
        }
        
        public TaskDto Delete(int id)
        {
            Task? task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return null;
            }
            _tasks.Remove(task);
            return _mapper.Map<TaskDto>(task);
        }

    }
}
