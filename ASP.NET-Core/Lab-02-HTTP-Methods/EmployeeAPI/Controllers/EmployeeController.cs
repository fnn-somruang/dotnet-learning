using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("api/employee")]

public class EmployeeController : ControllerBase
{
    private static List<Employee> employees = new()
    {
        new Employee { Id = 1, Name = "John", Position = "Developer" },
        new Employee { Id = 2, Name = "Sarah", Position = "Designer" }
    };

    [HttpGet(Name = "GetEmployees")]
    public object GetEmployees()
    {
        return employees;
    }

    [HttpGet("{id}", Name = "GetEmployeeById")]

    public object GetEmployeeById(int id)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound(new { message = "Employee not found" });
        }
        return employee;
    }

    [HttpPost(Name = "AddEmployee")]
    public object AddEmployee(Employee employee)
    {
        employee.Id = employees.Max(e => e.Id) + 1;
        employees.Add(employee);
        return CreatedAtRoute("GetEmployeeById", new { id = employee.Id }, employee);
    }

    [HttpPut("{id}", Name = "UpdateEmployee")]
    public object UpdateEmployee(int id, Employee employee)
    {
        var existingEmployee = employees.FirstOrDefault(e => e.Id == id);
        if (existingEmployee == null)
        {
            return NotFound(new { message = "Employee not found" });
        }
        existingEmployee.Name = employee.Name;
        existingEmployee.Position = employee.Position;
        return existingEmployee;
    }

    [HttpDelete("{id}", Name = "DeleteEmployee")]
    public object DeleteEmployee(int id)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
        {
            return NotFound(new { message = "Employee not found" });
        }
        employees.Remove(employee);
        return NoContent();
    }
}