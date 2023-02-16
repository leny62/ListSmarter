using System.Collections.Generic;
using ListSmarter.Models;

namespace ListSmarter.Services
{
    public interface IService
    {
        IList<TaskDto> GetAllTasks();
        TaskDto GetTaskById(int taskId);
        void UpdateTask(TaskDto taskDto);
        
        IList<BucketDto> GetAllBuckets();
        BucketDto GetBucketById(int bucketId);
        void UpdateBucket(BucketDto bucketDto);
        
        IList<PersonDto> GetAllPeople();
        PersonDto GetPersonById(int personId);
        void UpdatePerson(PersonDto personDto);
    }
}