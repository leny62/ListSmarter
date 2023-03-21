using ListSmarter.People.Dtos;

namespace ListSmarter.People.Business
{
    public interface IPersonService
    {
        IList<PersonDto> GetAll();
        PersonDto GetById(int personId);
        PersonDto Update(int id, PersonDto personDto);
        PersonDto Create(PersonDto personDto);
        PersonDto Delete(int id);
    }
}