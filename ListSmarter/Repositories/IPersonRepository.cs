using System.Collections.Generic;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        void Create(Person person);
        void Update(Person person);
        void Delete(Person person);
    }
}