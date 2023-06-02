class AddCommand : ICommand
{
    private readonly IEmployeesProvider _employeesProvider;

    public AddCommand(IEmployeesProvider employeesProvider)
    {
        _employeesProvider = employeesProvider;
    }

    public string GetAssignedCommandText() => "-add";

    public void Execute(string payload)
    {
        var employees = _employeesProvider.GetEmployees();

        var split = payload.Split(" ");
        var firstName = split[0].Split(":")[1];
        var lastName = split[1].Split(":")[1];
        var salaryPerHour = decimal.Parse(split[2].Split(":")[1]);
        var id = employees
            .DefaultIfEmpty()
            .Max(x => x?.Id ?? 0) + 1;

        var newEmployee = new Employee(id, firstName, lastName, salaryPerHour);

        employees.Add(newEmployee);
    }
}
