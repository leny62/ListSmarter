using System.Collections.Generic;
using System.Linq;
using Automapper;
using ListSmarter.Models;
using ListSmarter.Repositories.Models;

namespace ListSmarter.Repositories
{
    public class PersonRepository
    {
        public List<PersonDto> GetPeople()
        {
            using (var context = new ListSmarterContext())
            {
                var people = context.People.ToList();
                return Mapper.Map<List<PersonDto>>(people);
            }
        }
    }
}