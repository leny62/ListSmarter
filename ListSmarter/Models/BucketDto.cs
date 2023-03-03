using System.Collections.Generic;

namespace ListSmarter.Models
{
    public class BucketDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TaskDto>? Tasks { get; set; }
    }
}