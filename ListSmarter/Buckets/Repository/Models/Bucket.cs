using Task = ListSmarter.Tasks.Repository.Models.Task;

namespace ListSmarter.Buckets.Repository.Models
{
    public class Bucket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Task>? Tasks { get; set; } = new List<Task>();
    }
}