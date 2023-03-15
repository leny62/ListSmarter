using System.Collections.Generic;
using ListSmarter.DTOs;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Services
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