namespace ListSmarter.Repositories.Models
{
    public class Bucket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Task>? Tasks { get; set; } = new List<Task>();
    }
}