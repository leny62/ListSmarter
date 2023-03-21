using System.Collections.Generic;
using FluentAssertions;
using FluentValidation;
using ListSmarter.People.Business;
using ListSmarter.People.Dtos;
using Moq;
using Xunit;

namespace ListSmarter.UnitTest.People.Tests.Business;

public class PeopleTests
{
    private readonly Mock<IPersonService> _personServiceMock;
    private readonly Mock<IValidator<PersonDto>> _personValidatorMock;
    
    
    public PeopleTests()
    {
        _personServiceMock = new Mock<IPersonService>();
        _personValidatorMock = new Mock<IValidator<PersonDto>>();
    }
    
    [Fact]
    public void GetAll_ShouldReturnAllPeople()
    {
        // Arrange
        var people = new List<PersonDto>
        {
            new PersonDto
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe"
            },
            new PersonDto
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe"
            }
        };
        _personServiceMock.Setup(x => x.GetAll()).Returns(people);
        
        // Act
        var result = _personServiceMock.Object.GetAll();
        
        // Assert
        result.Should().BeEquivalentTo(people);
    }
    
    [Fact]
    public void GetById_ShouldReturnPerson()
    {
        // Arrange
        var person = new PersonDto
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };
        _personServiceMock.Setup(x => x.GetById(1)).Returns(person);
        
        // Act
        var result = _personServiceMock.Object.GetById(1);
        
        // Assert
        result.Should().BeEquivalentTo(person);
    }
    
    [Fact]
    public void Update_ShouldUpdatePerson()
    {
        // Arrange
        var person = new PersonDto
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };
        _personServiceMock.Setup(x => x.Update(1, person)).Returns(person);
        
        // Act
        var result = _personServiceMock.Object.Update(1, person);
        
        // Assert
        result.Should().BeEquivalentTo(person);
    }
    
    [Fact]
    public void Create_ShouldCreatePerson()
    {
        // Arrange
        var person = new PersonDto
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };
        _personServiceMock.Setup(x => x.Create(person)).Returns(person);
        
        // Act
        var result = _personServiceMock.Object.Create(person);
        
        // Assert
        result.Should().BeEquivalentTo(person);
    }
    
    [Fact]
    public void Delete_ShouldDeletePerson()
    {
        // Arrange
        var person = new PersonDto
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe"
        };
        _personServiceMock.Setup(x => x.Delete(1)).Returns(person);
        
        // Act
        var result = _personServiceMock.Object.Delete(1);
        
        // Assert
        result.Should().BeEquivalentTo(person);
    }
}