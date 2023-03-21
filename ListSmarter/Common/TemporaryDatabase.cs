using ListSmarter.Buckets.Repository.Models;
using ListSmarter.People.Repository.Models;
using ListSmarter.Tasks.Repository.Models;
using TaskModel = ListSmarter.Tasks.Repository.Models.Task;

namespace ListSmarter.Common
{
    public static class TemporaryDatabase
    {
       static Bucket TasksBucket = new BucketBuilder()
          .WithId(1)
          .WithTitle("The First Bucket")
          .Build();
       static Person LenyIhirwe = new PersonBuilder()
          .WithId(1)
          .WithFirstName("Leny Pascal")
          .WithLastName("Ihirwe")
          .Build();
       static TaskModel CodingTask = new TaskBuilder()
          .WithId(1)
          .WithTitle("Coding")
          .WithDescription("Coding is fun")
          .WithStatus(Status.InProgress)
          .Build();
      
         public static List<Bucket> Buckets = new List<Bucket>
         {
             TasksBucket
         };
         
            public static List<Person?> People = new List<Person?>
            {
                LenyIhirwe
            };
            
               public static List<TaskModel?> Tasks = new List<TaskModel?>
               {
                   CodingTask
               };
    }
}

