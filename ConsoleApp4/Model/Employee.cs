public class Employee
{
    public int Id { get; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal SalaryPerHour { get; set; }

    public Employee(int id, string firstName, string lastName, decimal salaryPerHour)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        SalaryPerHour = salaryPerHour;
    }
}
