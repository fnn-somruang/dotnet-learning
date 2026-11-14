// using Microsoft.AspNetCore.Mvc;

// namespace EmployeeAPI.Controllers;
// [ApiController]
// [Route("[controller]")]
// public class HelloController : ControllerBase
// {
//     [HttpGet(Name = "GetHello")]
//     public string Get()
//     {
//         return "Hello, World!";
//     }
// }

using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("api/hello")]
public class HelloController : ControllerBase
{
    [HttpGet(Name = "GetHello")]
    public object Get()
    {
        return new
        {
            message = "Hello, World!"
        };
    }
}