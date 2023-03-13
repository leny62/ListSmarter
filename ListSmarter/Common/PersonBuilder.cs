using ListSmarter.Repositories.Models;

namespace ListSmarter.Common;

public class PersonBuilder
{
    private int _id;
    private string _firstName;
    private string _lastName;
    
    public PersonBuilder WithId(int id)
    {
        _id = id;
        return this;
    }
    
    public PersonBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }
    
    public PersonBuilder WithLastName(string lastName)
    {
        _lastName = lastName;
        return this;
    }
    
    public Person Build()
    {
        return new Person
        {
            Id = _id,
            FirstName = _firstName,
            LastName = _lastName
        };
    }
}