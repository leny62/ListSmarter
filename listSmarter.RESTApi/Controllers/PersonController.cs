using FluentValidation;
using ListSmarter.Models;
using ListSmarter.Services;
using Microsoft.AspNetCore.Mvc;

namespace listSmarter.RESTApi.Controllers
{
    [Route("api/v1/people")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;
        
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }
        
        // Get all People
        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> GetAll()
        {
            var people = _personService.GetAllPeople();
            return Ok(people);
        }
        
        // Get a Person by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try 
            {
                var person = _personService.GetPersonById(id);
                return Ok(person);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Person with ID " + id + " not found");
            }
        }
        
        // Create a Person
        [HttpPost]
        public ActionResult<PersonDto> CreatePerson(PersonDto personDto)
        {
            try 
            {
                PersonDto person = _personService.CreatePerson(personDto);
                return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
        
        // Update a Person
        [HttpPut]
        public IActionResult UpdatePerson([FromRoute] int id, [FromBody] PersonDto personDto)
        {
            try 
            {
                PersonDto person = _personService.UpdatePerson(personDto.Id, personDto);
                return Ok(person);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Person with ID " + personDto.Id + " not found");
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}

