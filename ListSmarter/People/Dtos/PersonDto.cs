using ListSmarter.Tasks.Dtos;

namespace ListSmarter.People.Dtos
{
    public class PersonDto
    {
       public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public List<TaskDto>? Tasks { get; set; }
    }
}