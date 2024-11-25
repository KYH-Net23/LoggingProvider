using LoggingProvider.Models.API;
using Microsoft.AspNetCore.Mvc;

namespace LoggingProvider.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoggingController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> LogEvent([FromBody] List<UserEventRequest> userEvents)
    {
        try
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);  

            return Ok(userEvents);
        }
        catch (Exception ex) { return BadRequest(ex.Message); }
    }
}
