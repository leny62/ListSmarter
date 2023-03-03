using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using ListSmarter.Models;
using ListSmarter.Repositories;
using ListSmarter.Repositories.Models;
using FluentValidation;
using FluentValidation.Results;
using ListSmarter.Models.Validators;

namespace ListSmarter.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IValidator<PersonDto> _personValidator;

        public PersonService(IPersonRepository personRepository, IValidator<PersonDto> personValidator)
        {
            _personRepository = personRepository;
            _personValidator = personValidator ?? throw new ArgumentNullException(nameof(personValidator));
        }
        
        public IList<PersonDto> GetAllPeople()
        {
            return _personRepository.GetAll();
        }
        
        public PersonDto GetPersonById(int personId)
        {
            ValidatePersonId(personId);
            return _personRepository.GetById(personId);
        }
        
        public PersonDto UpdatePerson(int id, PersonDto personDto)
        {
            ValidatePersonId(id);
            return _personRepository.Update(id, personDto);
        }

        public void ValidatePersonId(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Person Id must be greater than 0");
            }
            // check Null
            if (_personRepository.GetById(id) == null)
            {
                throw new ValidationException("Person Id does not exist");
            }
        }

        public PersonDto CreatePerson(PersonDto personDto)
        {
            _personValidator.ValidateAndThrow(personDto);
            return _personRepository.Create(personDto);
        }
        
        public PersonDto DeletePerson(int id)
        {
            ValidatePersonId(id);
            return _personRepository.Delete(id);
        }
        
        public void ValidatePerson(PersonDto personDto)
        {
            var validator = new PersonDtoValidator();
            var result = validator.Validate(personDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}