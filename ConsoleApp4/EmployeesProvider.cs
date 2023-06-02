using System.Text.Json;

class EmployeesProvider : IEmployeesProvider
{
    private readonly List<Employee> _employees;
    private const string FileName = "Employees.json";
    
    public EmployeesProvider()
    {
        _employees = ReadEmployeesFromDisk();
    }

    public ICollection<Employee> GetEmployees()
    {
        return _employees;
    }

    private List<Employee> ReadEmployeesFromDisk()
    {
        if (!File.Exists(FileName))
            return new List<Employee>();

        var json = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<List<Employee>>(json)
            ?? throw new Exception("On loading something went wrong.");
    }

    public void SaveChanges()
    {
        if (File.Exists(FileName))
            File.Delete(FileName);

        var json = JsonSerializer.Serialize(_employees);
        File.WriteAllText(FileName, json);
    }
}
