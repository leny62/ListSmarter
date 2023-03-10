using TaskModel = ListSmarter.Repositories.Models.Task;
using TaskDto = ListSmarter.Models.TaskDto;
using ListSmarter.Repositories;
using ListSmarter.Services;
using ListSmarter.Models;
using ListSmarter.Models.Validators;
using ListSmarter.Repositories.Models;
using ListSmarter.Enums;

namespace ListSmarter.Common
{
    public static class TemporaryDatabase
    {
        public static List<Bucket> Buckets { get; set; } = new List<Bucket>();
        public static List<Person> People { get; set; } = new List<Person>();
        public static List<TaskModel> Tasks { get; set; } = new List<TaskModel>();

        static TemporaryDatabase()
        {
            CreateData();
        }

        public static void CreateData()
        {
            for (int i = 0; i < 10; i++)
            {
                Bucket bucket = new()
                {
                    Id = i,
                    Title = $"Bucket {i}",
                };
                Buckets.Add(bucket);
                
                Person person = new()
                {
                    Id = i,
                    FirstName = $"Person {i}" + "First" + i,
                    LastName = $"Person {i}" + "Last" + i,
                };
                People.Add(person);
                
                TaskModel task = new()
                {
                    Id = i,
                    Title = $"Task {i}",
                    Description = $"Task number {i}",
                    Status = (Status) System.Enum.Parse(typeof(Status), "Open"),
                };
                Tasks.Add(task);
            }
        }
    }
}

