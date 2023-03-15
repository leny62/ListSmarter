using FluentValidation;
using ListSmarter.DTOs;
using ListSmarter.Repositories.Models;
using ListSmarter.Services;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

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
        
        [HttpGet]
        public ActionResult<IEnumerable<PersonDto>> GetAll()
        {
            var people = _personService.GetAll();
            return Ok(people);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try 
            {
                var person = _personService.GetById(id);
                return Ok(person);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Person with ID " + id + " not found");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<PersonDto>> Create(PersonDto personDto)
        {
            try 
            {
                PersonDto person = _personService.Create(personDto);
                return await Task.FromResult(CreatedAtAction(nameof(GetById), new { id = person.Id }, person));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPut]
        public IActionResult UpdatePerson([FromRoute] int id, [FromBody] PersonDto personDto)
        {
            try 
            {
                PersonDto person = _personService.Update(personDto.Id, personDto);
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
        
        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            try 
            {
                _personService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Person with ID " + id + " not found");
            }
        }
    }
}

