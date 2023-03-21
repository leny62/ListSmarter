using FluentValidation;
using ListSmarter.Tasks.Dtos;
using ListSmarter.Tasks.Repository.Models;

namespace ListSmarter.Tasks.Business
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
        
        public TaskDto GetById(int id)
        {
            ValidateTaskId(id);
            return _taskRepository.GetTaskById(id);
        }
        
        public TaskDto Create(TaskDto task)
        {
            _taskValidator.ValidateAndThrow(task);
            return _taskRepository.Create(task);
        }
        
        public TaskDto Update(int id, TaskDto task)
        {
            ValidateTaskId(id);
            _taskValidator.ValidateAndThrow(task);
            return _taskRepository.Update(id, task);
        }
        
        public TaskDto Delete(int id)
        {
            ValidateTaskId(id);
            return _taskRepository.Delete(id);
        }
        
        public IList<TaskDto> GetAll()
        {
            return _taskRepository.GetAllTasks();
        }
        
        public TaskDto AssignTaskToPerson(int taskId, int personId)
        {
            ValidateTaskId(taskId);
            TaskDto task = _taskRepository.GetTaskById(taskId);
            task = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Assignee = personId
            };
            return _taskRepository.Update(taskId, task);
        }
        
        public TaskDto AssignTaskToBucket(int taskId, int bucketId)
        {
            ValidateTaskId(taskId);
            TaskDto task = _taskRepository.GetTaskById(taskId);
            task = new TaskDto
        {
                Id = task.Id,
                Title = task.Title,
                Bucket = bucketId
            };
            return _taskRepository.Update(taskId, task);
        }
        
        public TaskDto ChangeTaskStatus(int taskId, string status)
        {
            ValidateTaskId(taskId);
            TaskDto task = _taskRepository.GetTaskById(taskId);
            task = new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Status = (Status) System.Enum.Parse(typeof(Status), status)
            };
            return _taskRepository.Update(taskId, task);
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
