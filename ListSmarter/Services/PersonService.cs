using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using ListSmarter.Models;
using ListSmarter.Repositories;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private IPersonService _personServiceImplementation;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public PersonService(IMapper personRepository, PersonRepository mapper)
        {
            _mapper = personRepository;
            _personRepository = mapper;
        }

        public IEnumerable<PersonDto> GetAllPersons()
        {
            var persons = _personRepository.GetAll();
            return _mapper.Map<IEnumerable<PersonDto>>(persons);
        }

        public IList<TaskDto> GetAllTasks()
        {
            return _personServiceImplementation.GetAllTasks();
        }

        public TaskDto GetTaskById(int taskId)
        {
            return _personServiceImplementation.GetTaskById(taskId);
        }

        public void UpdateTask(TaskDto taskDto)
        {
            _personServiceImplementation.UpdateTask(taskDto);
        }

        public IList<BucketDto> GetAllBuckets()
        {
            return _personServiceImplementation.GetAllBuckets();
        }

        public BucketDto GetBucketById(int bucketId)
        {
            return _personServiceImplementation.GetBucketById(bucketId);
        }

        public void UpdateBucket(BucketDto bucketDto)
        {
            _personServiceImplementation.UpdateBucket(bucketDto);
        }

        public IList<PersonDto> GetAllPeople()
        {
            return _personServiceImplementation.GetAllPeople();
        }

        public PersonDto GetPersonById(int id)
        {
            var person = _personRepository.GetById(id);
            return _mapper.Map<PersonDto>(person);
        }

        public void CreatePerson(PersonDto person)
        {
            var personEntity = _mapper.Map<Person>(person);
            _personRepository.Create(personEntity);
        }

        public void UpdatePerson(PersonDto person)
        {
            var personEntity = _mapper.Map<Person>(person);
            _personRepository.Update(personEntity);
        }

        public void DeletePerson(int id)
        {
            var personEntity = _personRepository.GetById(id);
            if (personEntity == null)
            {
                throw new ArgumentException($"Person with ID {id} does not exist");
            }
            _personRepository.Delete(personEntity);
        }

        public void Create(PersonDto person)
        {
            var personEntity = _mapper.Map<Person>(person);
            _personRepository.Create(personEntity);
        }

        public PersonDto GetById(int parse)
        {
            var person = _personRepository.GetById(parse);
            return _mapper.Map<PersonDto>(person);
        }

        public void Update(object personToUpdate)
        {
            _personRepository.Update((Person) personToUpdate);
        }

        public IEnumerable<PersonDto> GetAll()
        {
            var persons = _personRepository.GetAll();
            return _mapper.Map<IEnumerable<PersonDto>>(persons);
        }

        public PersonDto Delete(int parse)
        {
            var personEntity = _personRepository.GetById(parse);
            if (personEntity == null)
            {
                throw new ArgumentException($"Person with ID {parse} does not exist");
            }
            _personRepository.Delete(personEntity);
            return _mapper.Map<PersonDto>(personEntity);
        }
    }
}