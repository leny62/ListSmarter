using AutoMapper;
using ListSmarter.Models;
using ListSmarter.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using FluentValidation;
using ListSmarter.Enums;
using ListSmarter.Repositories.Models;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IValidator<TaskDto> _taskValidator;
        
        public TaskService(ITaskRepository taskRepository, IValidator<TaskDto> taskValidator)
        {
            _taskRepository = taskRepository;
            _taskValidator = taskValidator;
        }
        
        public TaskDto GetTaskById(int id)
        {
            ValidateTaskId(id);
            return _taskRepository.GetById(id);
        }
        
        public TaskDto CreateTask(TaskDto task)
        {
            _taskValidator.ValidateAndThrow(task);
            return _taskRepository.Create(task);
        }
        
        public TaskDto UpdateTask(int id, TaskDto task)
        {
            ValidateTaskId(id);
            _taskValidator.ValidateAndThrow(task);
            return _taskRepository.Update(id, task);
        }
        
        public TaskDto DeleteTask(int id)
        {
            ValidateTaskId(id);
            return _taskRepository.Delete(id);
        }
        
        public IList<TaskDto> GetAll()
        {
            return _taskRepository.GetAll();
        }
        
        public TaskDto AssignTaskToPerson(int taskId, int personId)
        {
            ValidateTaskId(taskId);
            return _taskRepository.AssignTaskToPerson(taskId, personId);
        }
        
        public TaskDto AssignTaskToBucket(int taskId, int bucketId)
        {
            ValidateTaskId(taskId);
            return _taskRepository.AssignTaskToBucket(taskId, bucketId);
        }
        
        public TaskDto ChangeTaskStatus(int taskId, string status)
        {
            ValidateTaskId(taskId);
            return _taskRepository.ChangeTaskStatus(taskId, status);
        }

        private void ValidateTaskStatus(string status)
        {
          // Validate if the string is a valid enum identifier
            if (!Enum.IsDefined(typeof(TaskStatus), status))
            {
                throw new ArgumentException("Invalid Task Status");
            }
            // validate if string is not empty
            if (string.IsNullOrEmpty(status))
            {
                throw new ArgumentException("Task status cannot be empty");
            }
        }

        private void ValidateTaskId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Task id must be greater than 0");
            }
        }
    }
}
