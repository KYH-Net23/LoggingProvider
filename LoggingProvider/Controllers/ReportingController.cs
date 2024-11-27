using Microsoft.AspNetCore.Mvc;

namespace LoggingProvider.Controllers;

[Route("")]
[ApiController]
public class ReportingController : ControllerBase
{
    [HttpGet("/userEvents")]
    public async Task<IActionResult> GetUserEvents([FromQuery] string sortBy, [FromQuery] string orderBy)
    {
        return Ok();
    }

    [HttpGet("/adminEvents")]
    public async Task<IActionResult> GetAdminEvents()
    {
        return Ok();
    }
}
