public interface IEmployeesProvider
{
    ICollection<Employee> GetEmployees();
    void SaveChanges();
}