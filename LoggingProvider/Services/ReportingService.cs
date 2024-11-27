using LoggingProvider.Contexts;

namespace LoggingProvider.Services;

public class ReportingService(LoggingContext context)
{
    private readonly LoggingContext _context = context;
}
