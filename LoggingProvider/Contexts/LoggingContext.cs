using LoggingProvider.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoggingProvider.Contexts
{
    public class LoggingContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<UserEventEntity> UserEvents { get; set; }
        public DbSet<AdminEventEntity> AdminEvents { get; set; }
    }
}