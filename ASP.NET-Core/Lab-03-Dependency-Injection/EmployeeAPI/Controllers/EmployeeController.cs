using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Models;
using EmployeeAPI.Services;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("api/employee")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet(Name = "GetEmployees")]
    public ActionResult<List<Employee>> GetEmployees()
    {
        return Ok(_employeeService.GetEmployees());
    }

    [HttpGet("{id}", Name = "GetEmployeeById")]
    public ActionResult<Employee> GetEmployeeById(int id)
    {
        var employee = _employeeService.GetEmployeeById(id);

        if (employee == null)
        {
            return NotFound(new { message = "Employee not found" });
        }

        return Ok(employee);
    }

    [HttpPost(Name = "AddEmployee")]
    public ActionResult<Employee> AddEmployee(Employee employee)
    {
        var createdEmployee = _employeeService.AddEmployee(employee);

        return CreatedAtRoute(
            "GetEmployeeById",
            new { id = createdEmployee.Id },
            createdEmployee
        );
    }

    [HttpPut("{id}", Name = "UpdateEmployee")]
    public ActionResult<Employee> UpdateEmployee(int id, Employee employee)
    {
        var updatedEmployee = _employeeService.UpdateEmployee(id, employee);

        if (updatedEmployee == null)
        {
            return NotFound(new { message = "Employee not found" });
        }

        return Ok(updatedEmployee);
    }

    [HttpDelete("{id}", Name = "DeleteEmployee")]
    public IActionResult DeleteEmployee(int id)
    {
        var isDeleted = _employeeService.DeleteEmployee(id);

        if (!isDeleted)
        {
            return NotFound(new { message = "Employee not found" });
        }

        return NoContent();
    }
}