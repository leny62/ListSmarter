using ListSmarter.Models;
using ListSmarter.Services;
using Microsoft.AspNetCore.Mvc;

namespace listSmarter.RESTApi.Controllers;

public class PersonController : ControllerBase
{
   private readonly ILogger<PersonController> _logger;
   private readonly IPersonService _personService;
   
   public PersonController(ILogger<PersonController> logger, IPersonService personService)
   {
       _logger = logger;
       _personService = personService;
   }
   

   // Get a Person by Id
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var person = _personService.GetPersonById(id);
        if (person == null)
        {
            return NotFound("Person with ID " + id + " not found");
        }

        return Ok(person);
    }
    
    
}