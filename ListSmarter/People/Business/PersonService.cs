using FluentValidation;
using ListSmarter.People.Dtos;

namespace ListSmarter.People.Business
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
        
        public IList<PersonDto> GetAll()
        {
            return _personRepository.GetAll();
        }
        
        public PersonDto GetById(int personId)
        {
            ValidatePersonId(personId);
            return _personRepository.GetById(personId);
        }
        
        public PersonDto Update(int id, PersonDto personDto)
        {
            ValidatePersonId(id);
            return _personRepository.Update(id, personDto);
        }

        private void ValidatePersonId(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Person Id must be greater than 0");
            }
            if (_personRepository.GetById(id) == null)
            {
                throw new ValidationException("Person Id does not exist");
            }
        }

        public PersonDto Create(PersonDto personDto)
        {
            _personValidator.ValidateAndThrow(personDto);
            return _personRepository.Create(personDto);
        }
        
        public PersonDto Delete(int id)
        {
            ValidatePersonId(id);
            return _personRepository.Delete(id);
        }
    }
}