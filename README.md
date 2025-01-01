# ListSmarter

ListSmarter is a C#/.NET application designed to manage people, buckets, and tasks within those buckets. The project includes both a REST API and a Console UI, and it utilizes FluentValidation for input validation. Unit tests are also written to ensure the reliability of the application.

## Features

•  [**People Management**](#): Create, read, update, and delete people.

•  [**Bucket Management**](#): Create, read, update, and delete buckets.

•  [**Task Management**](#): Create, read, update, and delete tasks within buckets.

•  [**Task Assignment**](#): Assign tasks to people and buckets.

•  [**Task Status Management**](#): Change the status of tasks.


## Technologies Used

•  [**C#/.NET**](https://dotnet.microsoft.com/en-us/languages/csharp): Core programming language and framework.

•  [**ASP.NET Core**](https://learn.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-9.0): For building the REST API.

•  [**FluentValidation**](https://docs.fluentvalidation.net/): For validating input data.

•  [**Entity Framework Core**](https://learn.microsoft.com/en-us/ef/core/): For database operations.

•  [**xUnit**](https://xunit.net/): For unit testing.


## Getting Started

### Prerequisites

•  .NET SDK


### Installation

1. Clone the repository:
```bash
git clone hhttps://github.com/leny62/ListSmarter.git
cd ListSmarter

Restore dependencies:
dotnet restore

Build the project:
dotnet build

Run the application:
dotnet run --project ListSmarter.RESTApi

Running Tests
To run the unit tests, use the following command:

dotnet test

API Endpoints
The application runs on http://localhost:5033/.

Access the documentation on http://localhost:5033/swagger/index.html

Console UI
The Console UI provides a simple interface to interact with the application. To run the Console UI, use the following command:

dotnet run --project ListSmarter.ConsoleUI

Sample Unit Test
Here is a sample unit test for the People management functionality:

using FluentValidation.Results;
using Xunit;

namespace ListSmarter.UnitTest.People.Business
{
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
new PersonDto { Id = 1, FirstName = "John", LastName = "Doe" },
new PersonDto { Id = 2, FirstName = "Jane", LastName = "Doe" }
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
var person = new PersonDto { Id = 1, FirstName = "John", LastName = "Doe" };
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
var person = new PersonDto { Id = 1, FirstName = "John", LastName = "Doe" };
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
var person = new PersonDto { Id = 1, FirstName = "John", LastName = "Doe" };
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
var person = new PersonDto { Id = 1, FirstName = "John", LastName = "Doe" };
_personServiceMock.Setup(x => x.Delete(1)).Returns(person);

// Act
var result = _personServiceMock.Object.Delete(1);

// Assert
result.Should().BeEquivalentTo(person);
}

[Fact]
public void Create_WithInvalidData_ShouldNotCreatePerson()
{
// Arrange
var person = new PersonDto { Id = 1, FirstName = "John", LastName = "Doe" };
var validationResult = new ValidationResult(new List<ValidationFailure>
{
new ValidationFailure("FirstName", "First name is required"),
new ValidationFailure("LastName", "Last name is required")
});
_personValidatorMock.Setup(x => x.Validate(person)).Returns(validationResult);

// Act
var result = _personServiceMock.Object.Create(person);

// Assert
result.Should().BeNull();
}

[Fact]
public void Update_WithInvalidData_ShouldNotUpdatePerson()
{
// Arrange
var person = new PersonDto { Id = 1, FirstName = "John", LastName = "Doe" };
var validationResult = new ValidationResult(new List<ValidationFailure>
{
new ValidationFailure("FirstName", "First name is required"),
new ValidationFailure("LastName", "Last name is required")
});
_personValidatorMock.Setup(x => x.Validate(person)).Returns(validationResult);

// Act
var result = _personServiceMock.Object.Update(1, person);

// Assert
result.Should().BeNull();
}
}
}

Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

License
This project is licensed under the MIT License. See the LICENSE file for details.

Contact
For any inquiries, please contact lihirwe6@gmail.com.

