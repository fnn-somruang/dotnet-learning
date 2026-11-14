using EmployeeAPI.Data;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services;

public class DbEmployeeService : IEmployeeService
{
    private readonly AppDbContext _context;

    public DbEmployeeService(AppDbContext context)
    {
        _context = context;
    }

    public List<Employee> GetEmployees()
    {
        return _context.Employees.ToList();
    }

    public Employee? GetEmployeeById(int id)
    {
        return _context.Employees.Find(id);
    }

    public Employee AddEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return employee;
    }

    public Employee? UpdateEmployee(int id, Employee employee)
    {
        var existing = _context.Employees.Find(id);
        if (existing == null) return null;

        existing.Name = employee.Name;
        existing.Position = employee.Position;
        _context.SaveChanges();
        return existing;
    }

    public bool DeleteEmployee(int id)
    {
        var existing = _context.Employees.Find(id);
        if (existing == null) return false;

        _context.Employees.Remove(existing);
        _context.SaveChanges();
        return true;
    }
}