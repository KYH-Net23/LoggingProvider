using Microsoft.EntityFrameworkCore;

namespace LoggingProvider.Contexts
{
    public class LoggingContext : DbContext
    {
        public LoggingContext(DbContextOptions options) : base(options)
        {
        }
    }
}
