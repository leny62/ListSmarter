using ListSmarter.Enums;

namespace ListSmarter.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public PersonDto Assignee { get; set; }
        public BucketDto Bucket { get; set; }
    }
}