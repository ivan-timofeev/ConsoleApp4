using ConsoleApp4.Model;
using Moq;

namespace ConsoleApp4.Tests;

public class UpdateCommandUnitTests
{
    [Fact]
    public void Execute_EmployeeNotFound_ShouldThrowAnException()
    {
        // Arrange
        var employeesProviderMock = new Mock<IEmployeesProvider>();
        employeesProviderMock
            .Setup(x => x.GetEmployees())
            .Returns(new List<Employee>());

        var updateCommand = new UpdateCommand(employeesProviderMock.Object);


        // Act & Assert
        var ex = Assert.Throws<Exception>(() =>
        {
            updateCommand.Execute("Id:1 FirstName:James");
        });
        Assert.Equal(ErrorMessages.EmployeeNotFound, ex.Message);
    }

    [Fact]
    public void Execute_EmployeeFound_ShouldUpdateAnEmployee()
    {
        // Arrange
        var employee = new Employee(1, string.Empty, string.Empty, 0);
        var employeesProviderMock = new Mock<IEmployeesProvider>();
        employeesProviderMock
            .Setup(x => x.GetEmployees())
            .Returns(new List<Employee> { employee });

        var updateCommand = new UpdateCommand(employeesProviderMock.Object);


        // Act
        updateCommand.Execute("Id:1 FirstName:James");
        updateCommand.Execute("Id:1 LastName:White");
        updateCommand.Execute("Id:1 SalaryPerHour:1000");


        // Arrange
        Assert.Equal("James", employee.FirstName);
        Assert.Equal("White", employee.LastName);
        Assert.Equal(1000, employee.SalaryPerHour);
    }
}
