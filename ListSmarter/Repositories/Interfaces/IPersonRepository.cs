using System.Collections.Generic;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public interface IPersonRepository
    {
        IList<PersonDto> GetAll();
        PersonDto GetById(int id);
        PersonDto Create(PersonDto person);
        PersonDto Update(int id, PersonDto person);
        PersonDto Delete(int id);
    }
}