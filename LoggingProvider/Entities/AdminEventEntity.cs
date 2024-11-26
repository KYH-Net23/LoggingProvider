using System.ComponentModel.DataAnnotations;
using LoggingProvider.Enums;

namespace LoggingProvider.Entities;

public class AdminEventEntity
{
    [Key]
    public int Id { get; set; }
    public string? AdminId { get; set; }
    [Required]
    [MaxLength(50)]
    public string EventName { get; set; } = null!;
    [Required]
    public EventType EventType { get; set; }
    [Required]
    public DateTime EventTimeStamp { get; set; }
    [MaxLength(300)]
    public string? PageUrl { get; set; }
}