using ConsoleApp4.Model;

public class UpdateCommand : ICommand
{
    private readonly IEmployeesProvider _employeesProvider;

    public UpdateCommand(IEmployeesProvider employeesProvider)
    {
        _employeesProvider = employeesProvider;
    }

    public string GetAssignedCommandText() => "-update";

    public void Execute(string payload)
    {
        var employees = _employeesProvider.GetEmployees();

        var split = payload.Split(" ");

        var id = int.Parse(split[0].Split(":")[1]);
        var propertyName = split[1].Split(":")[0];
        var propertyNewValue = split[1].Split(":")[1];

        var employee = employees.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception(ErrorMessages.EmployeeNotFound);

        switch (propertyName)
        {
            case nameof(Employee.FirstName):
                employee.FirstName = propertyNewValue;
                break;
            case nameof(Employee.LastName):
                employee.LastName = propertyNewValue;
                break;
            case nameof(Employee.SalaryPerHour):
                employee.SalaryPerHour = decimal.Parse(propertyNewValue);
                break;
            default:
                throw new Exception("Provided property name can not be updated.");
        }
    }
}
