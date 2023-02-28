using System;
using AutoMapper;
using ListSmarter.Repositories;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;
using ListSmarter.Services;
using ListSmarter.Models.Validators;
using ListSmarter.Enums;
using Task = ListSmarter.Repositories.Models.Task;

namespace ListSmarter.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Bucket, BucketDto>();
                cfg.CreateMap<BucketDto, Bucket>();
                cfg.CreateMap<Person, PersonDto>();
                cfg.CreateMap<PersonDto, Person>();
                cfg.CreateMap<Task, TaskDto>()
                    .ForMember(dest => dest.Assignee, opt => opt.MapFrom(src => src.Assignee.Id))
                    .ForMember(dest => dest.Bucket, opt => opt.MapFrom(src => src.Bucket.Id));
                cfg.CreateMap<TaskDto, Task>();
            });
            
            var mapper = mapperConfig.CreateMapper();
            
            var bucketRepository = new BucketRepository(mapper);
            var bucketService = new BucketService(mapper, bucketRepository);
            
            var personRepository = new PersonRepository(mapper);
            var personService = new PersonService(mapper, personRepository);

            var taskRepository = new TaskRepository(mapper, personRepository);
            var taskService = new TaskService(mapper, taskRepository);
            
            // var bucketDto = new BucketDto
            // {
            //     Title = "Bucket 1",
            // };
            //
            // bucketService.Create(bucketDto);
            // Console.WriteLine(bucketDto.Title);
            // Console.WriteLine("The above is the created Bucket");

            while (true)
            {
                Console.WriteLine("Please select an option");
                Console.WriteLine("1. Create a bucket");
                Console.WriteLine("2. Update a bucket");
                Console.WriteLine("3. List all  Buckets");
                Console.WriteLine("4. Get a bucket by id");
                Console.WriteLine("5. Delete a bucket");
                
                // Person Menu
                Console.WriteLine("6. Create a person");
                Console.WriteLine("7. Update a person");
                Console.WriteLine("8. List all  Persons");
                Console.WriteLine("9. Get a person by id");
                Console.WriteLine("10. Delete a person");
                
                // Task Menu
                Console.WriteLine("11. Create a task");
                Console.WriteLine("12. Update a task");
                Console.WriteLine("13. List all  Tasks");
                Console.WriteLine("14. Get a task by id");
                Console.WriteLine("15. Delete a task");
                Console.WriteLine("16. Assign a person to a task");
                Console.WriteLine("17. Change Task Status");
                
                // Menu
                Console.WriteLine("18. Display Buckets and associated tasks and People in a Table Format");
                

                Console.WriteLine("19. Exit");
                
                var option = int.Parse(Console.ReadLine());

                TaskDto? task;
                string? newTitle;
                string? personId;
                PersonDto? person;
                IEnumerable<BucketDto>? buckets;
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Please enter a title for the bucket");
                        var title = Console.ReadLine();
                        var bucket = new BucketDto
                        {
                            Title = title,
                        };
                        bucketService.Create(bucket);
                        break;
                    case 2:
                        Console.WriteLine("Please enter the id of the bucket you want to update");
                        var id = Console.ReadLine();
                        var bucketToUpdate = bucketService.GetById(int.Parse(id));
                        Console.WriteLine("Please enter a new title for the bucket");
                        newTitle = Console.ReadLine();
                        bucketToUpdate.Title = newTitle;
                        bucketService.Update(bucketToUpdate);
                        break;
                    case 3:
                        Console.WriteLine("All buckets:");
                        buckets = bucketService.GetAll();
                        if (buckets == null)
                        {
                            Console.WriteLine("No buckets found");
                            break;
                        }
                        foreach (var b in buckets)
                        {
                            Console.WriteLine(b.Title);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Please enter the id of the bucket you want to get");
                        var bucketId = Console.ReadLine();
                        var bucketToGet = bucketService.GetById(int.Parse(bucketId));
                        if (bucketToGet == null)
                        {
                            Console.WriteLine("No bucket found");
                            break;
                        }
                        Console.WriteLine(bucketToGet.Title);
                        break;
                    case 5:
                        Console.WriteLine("Please enter the id of the bucket you want to delete");
                        var bucketToDeleteId = Console.ReadLine();
                        var bucketToDelete = bucketService.GetById(int.Parse(bucketToDeleteId));
                        if (bucketToDelete == null)
                        {
                            Console.WriteLine("No bucket found");
                            break;
                        }
                        bucketService.Delete(1);
                        Console.WriteLine($"Bucket {bucketToDelete.Title} deleted");
                        break;
                    case 6:
                        Console.WriteLine("Please enter the First Name for the person");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Please enter the Last Name for the person");
                        var lastName = Console.ReadLine();
                        person = new PersonDto
                        {
                            FirstName = firstName,
                            LastName = lastName,
                        };
                        personService.Create(person);
                        break;
                    case 7:
                        Console.WriteLine("Please enter the id of the person you want to update");
                        personId = Console.ReadLine();
                        var personToUpdate = personService.GetById(int.Parse(personId));
                        if (personToUpdate == null)
                        {
                            Console.WriteLine("No person found");
                            break;
                        }
                        Console.WriteLine("Please enter a new First Name for the person");
                        var newFirstName = Console.ReadLine();
                        Console.WriteLine("Please enter a new Last Name for the person");
                        var newLastName = Console.ReadLine();
                        personToUpdate = new PersonDto()
                        {
                            FirstName = newFirstName,
                            LastName = newLastName
                        };
                        personService.Update(personToUpdate);
                        break;
                    case 8:
                        Console.WriteLine("All persons:");
                        var persons = personService.GetAll();
                        if (persons == null)
                        {
                            Console.WriteLine("No persons found");
                            break;
                        }
                        foreach (var p in persons)
                        {
                            Console.WriteLine($"{p.Id} || {p.FirstName} {p.LastName}");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Please enter the id of the person you want to get");
                        var personToGetId = Console.ReadLine();
                        var personToGet = personService.GetById(int.Parse(personToGetId));
                        if (personToGet == null)
                        {
                            Console.WriteLine("No person found");
                            break;
                        }

                        ;
                        Console.WriteLine($"{personToGet.Id} || {personToGet.FirstName} {personToGet.LastName}");
                        break;
                    case 10:
                        Console.WriteLine("Please enter the id of the person you want to delete");
                        var personToDeleteId = Console.ReadLine();
                        var personToDelete = personService.GetById(int.Parse(personToDeleteId));
                        if (personToDelete == null)
                        {
                            Console.WriteLine("No person found");
                            break;
                        }
                        Console.WriteLine($"Person {personToDelete.FirstName} {personToDelete.LastName} deleted");
                        personService.Delete(int.Parse(personToDeleteId));
                        break;
                    case 11:
                        // task = new TaskDto();
                        // Console.WriteLine("Please enter the title for the task");
                        // task.Title = Console.ReadLine();
                        // Console.WriteLine("Please enter the description for the task");
                        // task.Description = Console.ReadLine();
                        // Console.WriteLine("Please select a status for the task:");
                        // Console.WriteLine("1. Not started");
                        // Console.WriteLine("2. In progress");
                        // Console.WriteLine("3. Completed");
                        //
                        // int statusChoice;
                        // while (!int.TryParse(Console.ReadLine(), out statusChoice) || statusChoice < 1 || statusChoice > 3)
                        // {
                        //     Console.WriteLine("Invalid choice. Please enter a number between 1 and 3:");
                        // }
                        //
                        // switch (statusChoice)
                        // {
                        //     case 1:
                        //         task.Status = Status.Open;
                        //         break;
                        //     case 2:
                        //         task.Status = Status.InProgress;
                        //         break;
                        //     case 3:
                        //         task.Status = Status.Closed;
                        //         break;
                        // };
                        //
                        // Console.WriteLine("Please enter the id of the bucket you want to assign the task to");
                        // var bucketIdForTask = Console.ReadLine();
                        // var bucketForTask = bucketService.GetById(int.Parse(bucketIdForTask));
                        // if (bucketForTask == null)
                        // {
                        //     Console.WriteLine("No bucket found");
                        //     break;
                        // }
                        //
                        // task.Bucket = int.Parse(bucketIdForTask);
                        // // log all entered data
                        // Console.WriteLine($"Title: {task.Title} + Description: {task.Description} + Status: {task.Status} + Bucket: {task.Bucket}");
                        taskService.CreateTask();
                        break;
                    case 12:
                        task = new TaskDto();
                        Console.WriteLine("Enter the Id of a task to update:");
                        var taskId = Console.ReadLine();
                        var taskToUpdate = taskService.GetById(int.Parse(taskId));
                        if (taskToUpdate == null)
                        {
                            Console.WriteLine("No task found");
                            break;
                        }
                        Console.WriteLine("Please enter a new title for the task");
                        newTitle = Console.ReadLine();
                        Console.WriteLine("Please enter a new description for the task");
                        var newDescription = Console.ReadLine();
                        Console.WriteLine("Please select a new status for the task:");
                        Console.WriteLine("1. Not started");
                        Console.WriteLine("2. In progress");
                        Console.WriteLine("3. Completed");
                        int newStatusChoice;
                        while (!int.TryParse(Console.ReadLine(), out newStatusChoice) || newStatusChoice < 1 || newStatusChoice > 3)
                        {
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3:");
                        }

                        switch (newStatusChoice)
                        {
                            case 1:
                                task.Status = Status.Open;
                                break;
                            case 2:
                                task.Status = Status.InProgress;
                                break;
                            case 3:
                                task.Status = Status.Closed;
                                break;
                        }

                        ;
                        Console.WriteLine("Please enter the id of the bucket you want to assign the task to");
                        var newBucketIdForTask = Console.ReadLine();
                        var newBucketForTask = bucketService.GetById(int.Parse(newBucketIdForTask));
                        if (newBucketForTask == null)
                        {
                            Console.WriteLine("No bucket found");
                            break;
                        }
                        Console.WriteLine("Enter the Id the person you want to assign the task to:");
                        var personIdForTask = Console.ReadLine();
                        var personForTask = personService.GetById(int.Parse(personIdForTask));
                        if (personForTask == null)
                        {
                            Console.WriteLine("No person found");
                            break;
                        }
                        taskToUpdate = new TaskDto()
                        {
                            Title = newTitle,
                            Description = newDescription,
                            Status = task.Status,
                            Bucket = int.Parse(newBucketIdForTask),
                            Assignee = int.Parse(personIdForTask)
                        };
                        taskService.Update(taskToUpdate);
                        break;
                    case 13:
                        Console.WriteLine("All tasks:");
                        try
                        {
                            var tasks = taskService.GetAll();
                            if (tasks == null)
                            {
                                Console.WriteLine("No tasks found");
                                break;
                            }
                            foreach (var t in tasks)
                            {
                                Console.WriteLine((object?)$"{t.Id} || {t.Title} || {t.Description} || {t.Status} || {t.Bucket} || {t.Assignee}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                        
                        break;
                    case 14:
                        Console.WriteLine("Enter the Id of the task");
                        var taskToGetId = Console.ReadLine();
                        var taskToGet = taskService.GetById(int.Parse(taskToGetId));
                        if (taskToGet == null)
                        {
                            Console.WriteLine("No task found");
                            break;
                        };
                        Console.WriteLine($"{taskToGet.Id} || {taskToGet.Title} || {taskToGet.Description} || {taskToGet.Status} || {taskToGet.Bucket} || {taskToGet.Assignee}");
                        break;
                    case 15:
                        Console.WriteLine("Enter the Id of the task you want to delete");
                        var taskToDeleteId = Console.ReadLine();
                        var taskToDelete = taskService.GetById(int.Parse(taskToDeleteId));
                        if (taskToDelete == null)
                        {
                            Console.WriteLine("No task found");
                            break;
                        }
                        Console.WriteLine($"Task {taskToDelete.Title} deleted");
                        taskService.DeleteTask(int.Parse(taskToDeleteId));
                        break;
                    case 16:
                        Console.WriteLine("Enter the Id of the person you want to assign to a task");
                        personId = Console.ReadLine();
                        person = personService.GetById(int.Parse(personId));
                        if (person == null)
                        {
                            Console.WriteLine("No person found");
                            break;
                        }
                        Console.WriteLine("Enter the Id of the task you want to assign to the person");
                        var taskIdForPerson = Console.ReadLine();
                        var taskForPerson = taskService.GetById(int.Parse(taskIdForPerson));
                        if (taskForPerson == null)
                        {
                            Console.WriteLine("No task found");
                            break;
                        }
                        taskForPerson.Assignee = int.Parse(personId);
                        // now we call AssignUserToTask method from TaskService
                        taskService.AssignUserToTask( int.Parse(personId), int.Parse(taskIdForPerson));
                        break;
                    case 17:
                        Console.WriteLine("Enter the Id of the task you want to update the status of");
                        Console.WriteLine();
                        int taskIdForTask = Convert.ToInt32(Console.ReadLine());
                        var taskForTask = taskService.GetById(taskIdForTask);
                        if (taskForTask == null)
                        {
                            Console.WriteLine("No task found");
                            break;
                        }
                        Console.WriteLine("Please select a new status for the task:"); 
                        Console.WriteLine("1. Open");
                        Console.WriteLine("2. In progress");
                        Console.WriteLine("3. Closed");
                        string newStatusChoiceForTask = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newStatusChoiceForTask) && Enum.IsDefined(typeof(Status), newStatusChoiceForTask))
                        {
                            taskForTask.Status = (Status)Enum.Parse(typeof(Status), newStatusChoiceForTask);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 3:");
                        } ;
                        taskService.UpdateTaskStatus(taskIdForTask, taskForTask.Status);
                        break;
                    case 18:
                        Console.WriteLine("ListSmarter Dashboard");
                        // display all buckets in a table format
                        buckets = bucketService.GetAll();
                        if (buckets == null)
                        {
                            Console.WriteLine("No buckets found");
                            break;
                        }
                        Console.WriteLine("Buckets:");
                        // Below display each bucket's tasks
                        foreach (var b in buckets)
                        {
                            var tasksOfBucket = taskService.GetAll().Where(t => t.Bucket == b.Id);
                            Console.WriteLine($"{b.Title}");
                            foreach (var t in tasksOfBucket)
                            {
                                Console.WriteLine($"{t.Id} || {t.Title} || {t.Description} || {t.Status} || {t.Bucket} || {t.Assignee}");
                            }
                        }
                        break;
                    case 19:
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }
}