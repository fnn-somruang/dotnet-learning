using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Models;
using EmployeeAPI.Services;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("api/employee")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly IDepartmentService _departmentService;

    // รับ Dependencies ทั้ง 2 ตัวพร้อมกันผ่าน Constructor
    public EmployeeController(
        IEmployeeService employeeService,
        IDepartmentService departmentService)
    {
        _employeeService = employeeService;
        _departmentService = departmentService;
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

    // Endpoint ใหม่ที่เรียกใช้งานทั้ง 2 Services ร่วมกัน
    [HttpGet("overview", Name = "GetCompanyOverview")]
    public IActionResult GetCompanyOverview()
    {
        var employees = _employeeService.GetEmployees();
        var departments = _departmentService.GetAll();

        return Ok(new
        {
            TotalEmployees = employees.Count,
            TotalDepartments = departments.Count(),
            Departments = departments,
            Employees = employees
        });
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