using EmployeeAPI.Models;

namespace EmployeeAPI.Services;

public interface IDepartmentService
{
    IEnumerable<Department> GetAll();
    Department? GetById(int id);
    bool Exists(int id);
}