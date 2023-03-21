namespace ListSmarter.Tasks.Repository.Models
{
    public class Task
    {
       public int Id { get; set; }
       public string Title { get; set; }
       public  string Description { get; set; }
       public Status Status { get; set; }
       public int Assignee { get; set; }
       public int? Bucket { get; set; }
    }
}