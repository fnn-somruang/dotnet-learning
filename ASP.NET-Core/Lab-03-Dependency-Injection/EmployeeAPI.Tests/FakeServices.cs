using EmployeeAPI.Models;
using EmployeeAPI.Services;

namespace EmployeeAPI.Tests;

// จำลอง EmployeeService สำหรับใช้ทดสอบโดยเฉพาะ
public class FakeEmployeeService : IEmployeeService
{
    private readonly List<Employee> _fakeEmployees = new()
    {
        new Employee { Id = 99, Name = "Test User", Position = "QA Engineer" }
    };

    public List<Employee> GetEmployees() => _fakeEmployees;

    public Employee? GetEmployeeById(int id) => 
        _fakeEmployees.FirstOrDefault(e => e.Id == id);

    public Employee AddEmployee(Employee employee)
    {
        employee.Id = 100;
        _fakeEmployees.Add(employee);
        return employee;
    }

    public Employee? UpdateEmployee(int id, Employee employee) => null;

    public bool DeleteEmployee(int id) => false;
}

// จำลอง DepartmentService สำหรับใช้ทดสอบโดยเฉพาะ
public class FakeDepartmentService : IDepartmentService
{
    public IEnumerable<Department> GetAll() => new List<Department>
    {
        new Department { Id = 1, Name = "Mock Dept", Location = "Floor 99" }
    };

    public Department? GetById(int id) => null;

    public bool Exists(int id) => id == 1;
}