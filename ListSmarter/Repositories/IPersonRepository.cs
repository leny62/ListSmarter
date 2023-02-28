using System.Collections.Generic;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<PersonDto> GetAll();
        PersonDto GetById(int id);
        PersonDto Create(Person person);
        void Update(Person person);
        void Delete(Person person);
        void Delete(PersonDto personEntity);
    }
}