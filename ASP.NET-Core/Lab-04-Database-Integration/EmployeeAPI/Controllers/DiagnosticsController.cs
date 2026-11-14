using EmployeeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiagnosticsController : ControllerBase
{
    private readonly ITransientOperation _transient;
    private readonly IScopedOperation _scoped;
    private readonly ISingletonOperation _singleton;
    private readonly SecondaryOperationService _secondaryService;

    public DiagnosticsController(
        ITransientOperation transient,
        IScopedOperation scoped,
        ISingletonOperation singleton,
        SecondaryOperationService secondaryService)
    {
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
        _secondaryService = secondaryService;
    }

    [HttpGet("lifetimes")]
    public IActionResult GetLifetimes()
    {
        return Ok(new
        {
            Controller = new
            {
                Transient = _transient.OperationId,
                Scoped = _scoped.OperationId,
                Singleton = _singleton.OperationId
            },
            SecondaryService = new
            {
                Transient = _secondaryService.Transient.OperationId,
                Scoped = _secondaryService.Scoped.OperationId,
                Singleton = _secondaryService.Singleton.OperationId
            }
        });
    }
}