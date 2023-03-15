using ListSmarter.DTOs;

namespace ListSmarter.Services.Interfaces
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