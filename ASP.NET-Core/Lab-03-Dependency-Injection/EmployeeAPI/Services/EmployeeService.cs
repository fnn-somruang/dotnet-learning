using EmployeeAPI.Models;

namespace EmployeeAPI.Services;

public class EmployeeService : IEmployeeService
{
    private static readonly List<Employee> employees = new()
    {
        new Employee { Id = 1, Name = "John", Position = "Developer" },
        new Employee { Id = 2, Name = "Sarah", Position = "Designer" }
    };

    public List<Employee> GetEmployees()
    {
        return employees;
    }

    public Employee? GetEmployeeById(int id)
    {
        return employees.FirstOrDefault(e => e.Id == id);
    }

    public Employee AddEmployee(Employee employee)
    {
        employee.Id = employees.Count == 0
            ? 1
            : employees.Max(e => e.Id) + 1;

        employees.Add(employee);

        return employee;
    }

    public Employee? UpdateEmployee(int id, Employee employee)
    {
        var existingEmployee = GetEmployeeById(id);

        if (existingEmployee == null)
        {
            return null;
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.Position = employee.Position;

        return existingEmployee;
    }

    public bool DeleteEmployee(int id)
    {
        var employee = GetEmployeeById(id);

        if (employee == null)
        {
            return false;
        }

        employees.Remove(employee);

        return true;
    }
}