using ListSmarter.People.Dtos;

namespace ListSmarter.People.Business
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