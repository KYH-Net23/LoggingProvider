using LoggingProvider.Contexts;
using LoggingProvider.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LoggingProvider.Services;

public class ReportingService(LoggingContext context, IMemoryCache cache)
{
    private readonly LoggingContext _context = context;
    private readonly IMemoryCache _cache = cache;

    public async Task<IEnumerable<UserEventEntity>> GetUserEventsAsync(int pageNumber, int pageSize)
    {
        var cacheKey = $"getUserEventsAsync_{pageNumber}_{pageSize}";

        if(!_cache.TryGetValue(cacheKey, out IEnumerable<UserEventEntity>? cachedUserEvents))
        {
            cachedUserEvents = await _context.UserEvents
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            _cache.Set(cacheKey, cachedUserEvents, TimeSpan.FromMinutes(10));
        }
        return cachedUserEvents!;
    }
}
