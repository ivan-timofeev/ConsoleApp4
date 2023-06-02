class GetAllCommand : ICommand
{
    private readonly IEmployeesProvider _employeesProvider;

    public GetAllCommand(IEmployeesProvider employeesProvider)
    {
        _employeesProvider = employeesProvider;
    }

    public string GetAssignedCommandText() => "-getall";

    public void Execute(string payload)
    {
        var employees = _employeesProvider.GetEmployees();

        foreach (var employee in employees)
        {
            Console.WriteLine("Id = {0}, FirstName = {1}, LastName = {2}, SalaryPerHour = {3}",
                employee.Id, employee.FirstName, employee.LastName, employee.SalaryPerHour);
        }
    }
}
