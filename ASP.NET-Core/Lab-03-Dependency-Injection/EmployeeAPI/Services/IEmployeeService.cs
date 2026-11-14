using EmployeeAPI.Models;

namespace EmployeeAPI.Services;

public interface IEmployeeService
{
    List<Employee> GetEmployees();

    Employee? GetEmployeeById(int id);

    Employee AddEmployee(Employee employee);

    Employee? UpdateEmployee(int id, Employee employee);

    bool DeleteEmployee(int id);
}