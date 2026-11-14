using EmployeeAPI.Controllers;
using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace EmployeeAPI.Tests;

public class EmployeeControllerTests
{
    [Fact]
    public void GetEmployees_ReturnsOkResult_WithListOfFakeEmployees()
    {
        // 1. Arrange: เตรียม Fake Services และฉีดเข้า Controller ด้วยมือ
        var fakeEmpService = new FakeEmployeeService();
        var fakeDeptService = new FakeDepartmentService();
        var controller = new EmployeeController(fakeEmpService, fakeDeptService);

        // 2. Act: เรียกใช้งาน Method ที่ต้องการทดสอบ
        var result = controller.GetEmployees();

        // 3. Assert: ตรวจสอบผลลัพธ์ว่าเป็น 200 OK และได้ข้อมูลจาก FakeService จริง
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var employees = Assert.IsType<List<Employee>>(okResult.Value);
        Assert.Single(employees); // ต้องมีแค่ 1 คนตามที่จำลองไว้
        Assert.Equal("Test User", employees[0].Name);
    }

    [Fact]
    public void GetEmployeeById_WhenIdDoesNotExist_ReturnsNotFound()
    {
        // Arrange
        var controller = new EmployeeController(new FakeEmployeeService(), new FakeDepartmentService());

        // Act: ลองค้นหา ID ที่ไม่มีอยู่ใน FakeEmployeeService
        var result = controller.GetEmployeeById(999);

        // Assert: ต้องคืนค่า HTTP 404 NotFound
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public void AddEmployee_ReturnsCreatedAtRoute_WithNewEmployee()
    {
        // Arrange
        var controller = new EmployeeController(new FakeEmployeeService(), new FakeDepartmentService());
        var newEmp = new Employee { Name = "Alice", Position = "DevOps" };

        // Act
        var result = controller.AddEmployee(newEmp);

        // Assert
        var createdResult = Assert.IsType<CreatedAtRouteResult>(result.Result);
        var returnedEmp = Assert.IsType<Employee>(createdResult.Value);
        Assert.Equal(100, returnedEmp.Id); // FakeEmployeeService จะกำหนด Id = 100 ให้เสมอ
        Assert.Equal("Alice", returnedEmp.Name);
    }
}