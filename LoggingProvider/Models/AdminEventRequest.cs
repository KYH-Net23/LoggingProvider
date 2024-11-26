using System.ComponentModel.DataAnnotations;

namespace LoggingProvider.Models
{
    public class AdminEventRequest
    {
        [Required]
        [MaxLength(50)]
        public string EventName { get; set; } = null!;
        public string? AdminId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EventType { get; set; } = null!;
        [Required]
        public DateTime EventTimeStamp { get; set; }
        [MaxLength(300)]
        public string? PageUrl { get; set; }
    }
}