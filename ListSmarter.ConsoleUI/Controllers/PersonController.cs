using FluentValidation;
using ListSmarter.Services;
using ListSmarter.Models;

namespace ListSmarter.ConsoleUI.Controllers;

public class PersonController
{
   private IPersonService _personService;
   private ITaskService _taskService;
   private IValidator<PersonDto> _personValidator;
   private IValidator<TaskDto> _taskValidator;
   
   public PersonController(IPersonService personService, ITaskService taskService, IValidator<PersonDto> personValidator, IValidator<TaskDto> taskValidator)
   {
       _personService = personService;
       _taskService = taskService;
       _personValidator = personValidator;
       _taskValidator = taskValidator;
   }
   
    public void Create()
    {
         Console.WriteLine("Enter first name:");
         var firstName = Console.ReadLine();
         Console.WriteLine("Enter last name:");
         var lastName = Console.ReadLine();
         var person = new PersonDto
         {
                Id = _personService.GetAll().Max(p => p.Id) + 1,
              FirstName = firstName,
              LastName = lastName
         };
         _personValidator.ValidateAndThrow(person);
         _personService.Create(person);
    }
    
    public void GetAll()
    {
        var people = _personService.GetAll();
        foreach (var person in people)
        {
            Console.WriteLine($"Id: {person.Id}, First Name: {person.FirstName}, Last Name: {person.LastName}");
        }
    }
    
    public void GetById()
    {
        Console.WriteLine("Enter person id:");
        var id = int.Parse(Console.ReadLine());
        var person = _personService.GetById(id);
        Console.WriteLine($"Id: {person.Id}, First Name: {person.FirstName}, Last Name: {person.LastName}");
    }
    
    public void Update()
    {
        Console.WriteLine("Enter person id:");
        var id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter first name:");
        var firstName = Console.ReadLine();
        Console.WriteLine("Enter last name:");
        var lastName = Console.ReadLine();
        var person = new PersonDto
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName
        };
        _personValidator.ValidateAndThrow(person);
        _personService.Update(id, person);
    }
    
    
    public void Delete()
    {
        Console.WriteLine("Enter person id:");
        var id = int.Parse(Console.ReadLine());
        _personService.Delete(id);
    }
}