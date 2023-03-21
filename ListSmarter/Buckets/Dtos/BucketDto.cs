using ListSmarter.Tasks.Dtos;

namespace ListSmarter.Buckets.Dtos
{
    public class BucketDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TaskDto>? Tasks { get; set; }
    }
}