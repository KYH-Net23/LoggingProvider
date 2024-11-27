using Azure.Core;
using LoggingProvider.Contexts;
using LoggingProvider.Factories;
using LoggingProvider.Models;
using LoggingProvider.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoggingProvider.Controllers;

[Route("")]
[ApiController]
public class LoggingController(LoggingService service) : ControllerBase
{
    private readonly LoggingService _service = service;

    [HttpPost("createuserevent/")]
    public async Task<IActionResult> LogUserEvent([FromBody] List<UserEventRequest> requests)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (requests.Count < 1 || requests == null) return NotFound(ModelState);

            await _service.CreateUserEventsAsync(requests);
            return Ok(requests);
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message); 
        }
    }

    [HttpPost("createadminevent/")]
    public async Task<IActionResult> LogAdminEvent([FromBody] AdminEventRequest request)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (request == null) return NotFound(ModelState);

            await _service.CreateAdminEventAsync(request);
            return Ok(request);
        }
        catch (Exception ex) 
        { 
            return BadRequest(ex.Message);
        }
    }
}