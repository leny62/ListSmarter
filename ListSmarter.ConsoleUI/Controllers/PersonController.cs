using FluentValidation;
using ListSmarter.Repositories.Models;
using ListSmarter.Services;
using ListSmarter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
   
    public void CreatePerson()
    {
         Console.WriteLine("Enter first name:");
         var firstName = Console.ReadLine();
         Console.WriteLine("Enter last name:");
         var lastName = Console.ReadLine();
         var person = new PersonDto
         {
                Id = _personService.GetAllPeople().Max(p => p.Id) + 1,
              FirstName = firstName,
              LastName = lastName
         };
         _personValidator.ValidateAndThrow(person);
         _personService.CreatePerson(person);
    }
    
    // Get all people
    public void GetAllPeople()
    {
        var people = _personService.GetAllPeople();
        foreach (var person in people)
        {
            Console.WriteLine($"Id: {person.Id}, First Name: {person.FirstName}, Last Name: {person.LastName}");
        }
    }
    
    // Get person by id
    public void GetPersonById()
    {
        Console.WriteLine("Enter person id:");
        var id = int.Parse(Console.ReadLine());
        var person = _personService.GetPersonById(id);
        Console.WriteLine($"Id: {person.Id}, First Name: {person.FirstName}, Last Name: {person.LastName}");
    }
    
    // Update person
    public void UpdatePerson()
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
        _personService.UpdatePerson(id, person);
    }
    
    
    // Delete person
    public void DeletePerson()
    {
        Console.WriteLine("Enter person id:");
        var id = int.Parse(Console.ReadLine());
        _personService.DeletePerson(id);
    }
}