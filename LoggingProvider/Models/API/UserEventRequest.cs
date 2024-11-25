using System.ComponentModel.DataAnnotations;

namespace LoggingProvider.Models.API;

public class UserEventRequest
{
    [Required]
    [MaxLength(50)]
    public string EventName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string EventType { get; set; } = null!; // Enum?

    [Required]
    public DateTime EventTimeStamp { get; set; }

    [MaxLength(100)]
    public string? PageUrl { get; set; }

    [MaxLength(100)]
    public string? SessionId { get; set; }
}
