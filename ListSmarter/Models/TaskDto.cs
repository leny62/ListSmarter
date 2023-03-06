using ListSmarter.Enums;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Person Assignee { get; set; }
        public Bucket Bucket { get; set; }
    }
}