using System.ComponentModel.DataAnnotations;

namespace LoggingProvider.Models.Entities;

public class UserEventEntity
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string EventName { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string EventType { get; set; } = null!; // Enum?

    [Required]
    public DateTime EventTimeStamp { get; set; }

    [MaxLength(2083)]
    public string? PageUrl { get; set; }

    [MaxLength(100)]
    public string? SessionId { get; set; }

}
