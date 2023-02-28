using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMapper _mapper;
        private readonly List<Person> _persons = new List<Person>();
        private IPersonRepository _personRepositoryImplementation;

        public PersonRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<PersonDto> GetAll()
        {
            return _mapper.Map<IEnumerable<PersonDto>>(_persons);
        }

        public PersonDto GetById(int id)
        {
            var person = _persons.FirstOrDefault(p => p.Id == id);
            return _mapper.Map<PersonDto>(person);
        }
        

        public void Update(Person person)
        {
            _personRepositoryImplementation.Update(person);
        }

        public void Delete(Person person)
        {
            _personRepositoryImplementation.Delete(person);
        }

        public void Delete(PersonDto personEntity)
        {
           var personToDelete = _persons.FirstOrDefault(p => p.Id == personEntity.Id);
            if (personToDelete != null)
            {
                _persons.Remove(personToDelete);
            }
        }

        public PersonDto Create(Person personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            person.Id = _persons.Any() ? _persons.Max(p => p.Id) + 1 : 1;
            _persons.Add(person);
            return _mapper.Map<PersonDto>(person);
        }

    }
}