using System.ComponentModel.DataAnnotations;

namespace LoggingProvider.Models;

public class UserEventResponse
{
    public string EventName { get; set; } = null!;
    public string? UserId { get; set; }
    public string EventType { get; set; } = null!;
    public string EventTimeStamp { get; set; } = null!;
    public string? PageUrl { get; set; }
    public string? SessionId { get; set; }
}
