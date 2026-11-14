using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    [HttpGet(Name = "GetStudent")]
    public object Get()
    {
        return new
        {
            name = "Nawapon Somruang",
            major = "Software Engineering",
            university = "Chiang Mai University",
        };
    }
}