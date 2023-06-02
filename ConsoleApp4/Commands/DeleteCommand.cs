using ConsoleApp4.Model;

class DeleteCommand : ICommand
{
    private readonly IEmployeesProvider _employeesProvider;

    public DeleteCommand(IEmployeesProvider employeesProvider)
    {
        _employeesProvider = employeesProvider;
    }

    public string GetAssignedCommandText() => "-delete";

    public void Execute(string payload)
    {
        var employees = _employeesProvider.GetEmployees();

        var id = int.Parse(payload.Split(":")[1]);

        var employee = employees.FirstOrDefault(x => x.Id == id)
            ?? throw new Exception(ErrorMessages.EmployeeNotFound);

        employees.Remove(employee);
    }
}
