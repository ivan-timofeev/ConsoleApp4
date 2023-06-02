using ConsoleApp4.Model;

class GetCommand : ICommand
{
    private readonly IEmployeesProvider _employeesProvider;

    public GetCommand(IEmployeesProvider employeesProvider)
    {
        _employeesProvider = employeesProvider;
    }

    public string GetAssignedCommandText() => "-get";

    public void Execute(string payload)
    {
        var employees = _employeesProvider.GetEmployees();

        var id = int.Parse(payload.Split(":")[1]);

        var employee = employees.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception(ErrorMessages.EmployeeNotFound);

        Console.WriteLine("Id = {0}, FirstName = {1}, LastName = {2}, SalaryPerHour = {3}",
            employee.Id, employee.FirstName, employee.LastName, employee.SalaryPerHour);
    }
}
