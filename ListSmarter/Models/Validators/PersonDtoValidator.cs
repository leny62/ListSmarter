namespace ListSmarter.Models.Validators
{
    public class PersonDtoValidator
    {
        public static bool Validate(PersonDto person)
        {
            if (person == null)
            {
                return false;
            }
            if (person.Id < 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(person.FirstName))
            {
                return false;
            }
            if (string.IsNullOrEmpty(person.LastName))
            {
                return false;
            }
            if (person.Tasks == null)
            {
                return false;
            }
            return true;
        }
    }
}