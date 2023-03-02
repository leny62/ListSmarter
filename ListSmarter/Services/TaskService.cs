using AutoMapper;
using ListSmarter.Models;
using ListSmarter.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ListSmarter.Enums;
using ListSmarter.Repositories.Models;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;

        public TaskService(IMapper mapper, ITaskRepository taskRepository)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
        }
        
        public void AssignUserToTask(int userId, int taskId)
        {
            _taskRepository.AssignUserToTask(userId, taskId);
        }

        public void UpdateTask(int taskDto)
        {
            var task = _mapper.Map<Task>(taskDto);
            _taskRepository.Update(task);
        }

        public void DeleteTask(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var taskToDelete = _taskRepository.GetById(id);
            _taskRepository.Delete(taskToDelete);
        }

        public TaskDto GetTaskById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID specified");
            }

            var task = _taskRepository.GetById(id);
            return _mapper.Map<TaskDto>(task);
        }

        public IEnumerable<TaskDto> GetTasksByBucketId(int bucketId)
        {
            if (bucketId <= 0)
            {
                throw new ArgumentException("Invalid bucket ID specified");
            }

            var tasks = _taskRepository.GetByBucketId(bucketId);
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public IEnumerable<TaskDto> GetTasksByBucketIdAndStatus(int bucketId, string status)
        {
            if (bucketId <= 0)
            {
                throw new ArgumentException("Invalid bucket ID specified");
            }

            if (string.IsNullOrWhiteSpace(status))
            {
                throw new ArgumentException("Invalid status specified");
            }

            var tasks = _taskRepository.GetByBucketIdAndStatus(bucketId, status);
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public TaskDto CreateTask(TaskDto taskDto)
        {
            if (taskDto == null)
            {
                throw new ArgumentNullException(nameof(taskDto));
            }

            var task = _mapper.Map<Task>(taskDto);
            _taskRepository.Create(task);
            return _mapper.Map<TaskDto>(task);
        }

        public void UpdateTask(TaskDto taskDto)
        {
            if (taskDto == null)
            {
                throw new ArgumentNullException(nameof(taskDto));
            }

            Repositories.Models.Task taskToUpdate = _taskRepository.GetById(taskDto.Id);
            if (taskToUpdate == null)
            {
                throw new ArgumentException("Invalid task ID specified");
            }
            _mapper.Map(taskDto, taskToUpdate);
            _taskRepository.Update(taskToUpdate);
        }

        public void UpdateTaskStatus(int taskId, Status status)
        {
            if (taskId <= 0)
            {
                throw new ArgumentException("Invalid task ID specified");
            }

            if (status == null)
            {
                throw new ArgumentNullException(nameof(status));
            }
            
            _taskRepository.UpdateTaskStatus(taskId, status);
        }

        public TaskDto GetById(int id)
        {
            var task = _taskRepository.GetById(id);
            return _mapper.Map<TaskDto>(task);
        }

        public void Update(TaskDto taskToUpdate)
        {
            if (taskToUpdate == null)
            {
                throw new ArgumentException();
            }
            Task task;
            task = _mapper.Map<Task>(taskToUpdate);
            _taskRepository.Update(task);
        }

        public IEnumerable<TaskDto> GetAll()
        {
            var tasks = _taskRepository.GetAll();
            return _mapper.Map<IEnumerable<TaskDto>>(tasks);
        }

        public void CreateTask()
        {
            var newTask = new Task();
            newTask.Id = _taskRepository.GetNextId();
            newTask.Description = "New Task";
            newTask.Status = Status.Open;
            newTask.Bucket = new Bucket();
            newTask.Assignee = new Person();
            
            _taskRepository.Create(newTask);
        }
    }
}
