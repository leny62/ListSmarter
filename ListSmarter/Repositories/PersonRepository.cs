using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ListSmarter.Repositories.Models;
using ListSmarter.Common;
using ListSmarter.DTOs;
using ListSmarter.Services.Interfaces;

namespace ListSmarter.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMapper _mapper;
        private List<Person?> _persons;

        public PersonRepository(IMapper mapper)
        {
            _mapper = mapper;
            _persons = TemporaryDatabase.People;
        }

        public IList<PersonDto> GetAll()
        {
            return _mapper.Map<IList<PersonDto>>(_persons);
        }

        public PersonDto GetById(int id)
        {
            Person person = _persons.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return null;
            }
            return _mapper.Map<PersonDto>(person);
        }
        

        public PersonDto Update(int id, PersonDto person)
        {
            Person personToUpdate = _persons.FirstOrDefault(p => p.Id == id);
            if (personToUpdate == null)
            {
                return null;
            }
            personToUpdate.FirstName = person.FirstName;
            personToUpdate.LastName = person.LastName;
            return _mapper.Map<PersonDto>(personToUpdate);
        }

        public PersonDto Delete(int id)
        {
            Person? personToDelete = _persons.FirstOrDefault(p => p.Id == id);
            if (personToDelete == null)
            {
                return null;
            }
            _persons.Remove(personToDelete);
            return _mapper.Map<PersonDto>(personToDelete);
        }
        
        public PersonDto Create(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            person.Id = _persons.Any() ? _persons.Max(p => p.Id) + 1 : 1;
            _persons.Add(person);
            return _mapper.Map<PersonDto>(person);
        }

    }
}