using EmployeeAPI.Models;

namespace EmployeeAPI.Services;

public class DepartmentService : IDepartmentService
{
    private readonly List<Department> _departments = new()
    {
        new Department { Id = 1, Name = "Engineering", Location = "Building A" },
        new Department { Id = 2, Name = "Human Resources", Location = "Building B" },
        new Department { Id = 3, Name = "Marketing", Location = "Building C" }
    };

    public IEnumerable<Department> GetAll() => _departments;

    public Department? GetById(int id) => _departments.FirstOrDefault(d => d.Id == id);

    public bool Exists(int id) => _departments.Any(d => d.Id == id);
}