using ListSmarter.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using ListSmarter.ConsoleUI.Controllers;
using ListSmarter.Models;
using ListSmarter.Repositories;
using ListSmarter.Repositories.Models;
using ListSmarter.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Task = ListSmarter.Repositories.Models.Task;
using ListSmarter.ConsoleUI.Controllers;
using ListSmarter.Models.Validators;
using AutoMapper;

namespace ListSmarter.ConsoleUI
{
    class Program
    {
        static IServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();
            
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IValidator<PersonDto>, PersonDtoValidator>();
            
            // Bucket 
            services.AddSingleton<IBucketRepository, BucketRepository>();
            services.AddSingleton<IBucketService, BucketService>();
            services.AddSingleton<IValidator<BucketDto>, BucketDtoValidator>();
            
            // Task
            
            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddSingleton<ITaskService, TaskService>();
            services.AddSingleton<IValidator<TaskDto>, TaskDtoValidator>();
            
            // AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
            return services.BuildServiceProvider();
        }
        
        static void Main(string[] args)
        {
            var serviceProvider = CreateServiceProvider();
            var personService = serviceProvider.GetService<IPersonService>();
            var personController = new PersonController(personService, serviceProvider.GetService<ITaskService>(), serviceProvider.GetService<IValidator<PersonDto>>(), serviceProvider.GetService<IValidator<TaskDto>>());
            var bucketService = serviceProvider.GetService<IBucketService>();
            var bucketController = new BucketController(bucketService, serviceProvider.GetService<ITaskService>(), serviceProvider.GetService<IValidator<BucketDto>>(), serviceProvider.GetService<IValidator<TaskDto>>());
            
            var taskService = serviceProvider.GetService<ITaskService>();
            var taskController = new TaskController(taskService, serviceProvider.GetService<IPersonService>(), serviceProvider.GetService<IBucketService>(), serviceProvider.GetService<IValidator<TaskDto>>());

            while (true)
            {
                // People
                Console.WriteLine("1. Create a Person");
                Console.WriteLine("2. Get All People");
                Console.WriteLine("3. Get Person By Id");
                Console.WriteLine("4. Update Person");
                Console.WriteLine("5. Delete Person");
                
                // Bucket
                Console.WriteLine("6. Create a Bucket");
                Console.WriteLine("7. Get All Buckets");
                Console.WriteLine("8. Get Bucket By Id");
                Console.WriteLine("9. Update Bucket");
                Console.WriteLine("10. Delete Bucket");
                
                // Task
                
                Console.WriteLine("11. Create a Task");
                Console.WriteLine("12. Get All Tasks");
                Console.WriteLine("13. Get Task By Id");
                Console.WriteLine("14. Update Task");
                Console.WriteLine("15. Delete Task");
                Console.WriteLine("16. Assign Task to Person");
                Console.WriteLine("17. Assign Task to Bucket");
                Console.WriteLine("18. Change Task Status");
                Console.WriteLine("19. Get All Tasks for a Person");
                Console.WriteLine("20. Get All Tasks for a Bucket");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        personController.GetAllPeople();
                        break;
                    case "2":
                        personController.CreatePerson();
                        break;
                    case "3":
                        personController.GetPersonById();
                        break;
                    case "4":
                        personController.UpdatePerson();
                        break;
                    case "5":
                        personController.DeletePerson();
                        break;
                    case "6":
                        bucketController.CreateBucket();
                        break;
                    case "7":
                        bucketController.GetAllBuckets();
                        break;
                    case "8":
                        bucketController.GetBucketById();
                        break;
                    case "9":
                        bucketController.UpdateBucket();
                        break;
                    case "10":
                        bucketController.DeleteBucket();
                        break;
                    case "11":
                        taskController.CreateTask();
                        break;
                    case "12":
                        taskController.GetAllTasks();
                        break;
                    case "13":
                        taskController.GetTaskById();
                        break;
                    case "14":
                        taskController.UpdateTask();
                        break;
                    case "15":
                        taskController.DeleteTask();
                        break;
                    case "16":
                        taskController.AssignTaskToPerson();
                        break;
                    case "17":
                        taskController.AssignTaskToBucket();
                        break;
                    case "18":
                        taskController.ChangeTaskStatus();
                        break;
                    case "19":
                        taskController.GetAllTasksForPerson();
                        break;
                    case "20":
                        taskController.GetAllTasksForBucket();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}