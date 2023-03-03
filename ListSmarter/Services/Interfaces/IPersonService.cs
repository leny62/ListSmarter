using System.Collections.Generic;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Services
{
    public interface IPersonService
    {
        IList<PersonDto> GetAllPeople();
        PersonDto GetPersonById(int personId);
        PersonDto UpdatePerson(int id, PersonDto personDto);
        PersonDto CreatePerson(PersonDto personDto);
        PersonDto DeletePerson(int id);
    }
}