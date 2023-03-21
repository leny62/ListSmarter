using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using ListSmarter.Buckets.Business;
using ListSmarter.Buckets.Dtos;
using ListSmarter.Buckets.Repository;
using ListSmarter.Buckets.Validators;
using ListSmarter.People.Business;
using ListSmarter.People.Dtos;
using ListSmarter.People.Repository;
using ListSmarter.People.Validators;
using listSmarter.RESTApi.Controllers;
using ListSmarter.Tasks.Business;
using ListSmarter.Tasks.Dtos;
using ListSmarter.Tasks.Repository;
using ListSmarter.Tasks.Validators;

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
            
            services.AddSingleton<IBucketRepository, BucketRepository>();
            services.AddSingleton<IBucketService, BucketService>();
            services.AddSingleton<IValidator<BucketDto>, BucketDtoValidator>();
            
            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddSingleton<ITaskService, TaskService>();
            services.AddSingleton<IValidator<TaskDto>, TaskDtoValidator>();
            
            services.AddAutoMapper(typeof(AutoMapperProfile));
            return services.BuildServiceProvider();
        }
        
        static void Main(string[] args)
        {
            // configure controllers from ListSmarter.RestApi   
            var serviceProvider = CreateServiceProvider();
            var personController = serviceProvider.GetService<PersonController>();
            var bucketController = serviceProvider.GetService<BucketController>();
            var taskController = serviceProvider.GetService<TasksController>();

            while (true)
            {
                Console.WriteLine("1. Create a Person");
                Console.WriteLine("2. Get All People");
                Console.WriteLine("3. Get Person By Id");
                Console.WriteLine("4. Update Person");
                Console.WriteLine("5. Delete Person");
                
                Console.WriteLine("6. Create a Bucket");
                Console.WriteLine("7. Get All Buckets");
                Console.WriteLine("8. Get Bucket By Id");
                Console.WriteLine("9. Update Bucket");
                Console.WriteLine("10. Delete Bucket");
                
                
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
                        personController.GetAll();
                        break;
                    case "2":
                        Console.WriteLine("Enter the First Name: ");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Enter the Last Name: ");
                        var lastName = Console.ReadLine();
                        PersonDto personDto = new PersonDto
                        {
                            FirstName = firstName,
                            LastName = lastName
                        };
                        personController.Create(personDto);
                        break;
                    case "3":
                        Console.WriteLine("Enter the Id: ");
                        var id = Console.ReadLine();
                        personController.GetById(Int32.Parse(id));
                        break;
                    case "4":
                        personController.Update();
                        break;
                    case "5":
                        personController.Delete();
                        break;
                    case "6":
                        bucketController.Create();
                        break;
                    case "7":
                        bucketController.GetAll();
                        break;
                    case "8":
                        bucketController.GetById();
                        break;
                    case "9":
                        bucketController.Update();
                        break;
                    case "10":
                        bucketController.Delete();
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