using System.ComponentModel.DataAnnotations;

namespace LoggingProvider.Models;

public class UserEventRequest
{
    [Required]
    [MaxLength(50)]
    public string EventName { get; set; } = null!;
    public string? UserId { get; set; }
    [Required]
    [MaxLength(50)]
    public string EventType { get; set; } = null!;
    [Required]
    public DateTime EventTimeStamp { get; set; }
    [MaxLength(300)]
    public string? PageUrl { get; set; }
    [MaxLength(300)]
    public string? SessionId { get; set; }
}