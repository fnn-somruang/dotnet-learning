using EmployeeAPI.Data;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services;

public class DbDepartmentService : IDepartmentService
{
    private readonly AppDbContext _context;

    public DbDepartmentService(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Department> GetAll() => _context.Departments.ToList();

    public Department? GetById(int id) => _context.Departments.Find(id);

    public bool Exists(int id) => _context.Departments.Any(d => d.Id == id);
}