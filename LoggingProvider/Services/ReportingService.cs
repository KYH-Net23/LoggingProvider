using LoggingProvider.Contexts;
using LoggingProvider.Entities;
using LoggingProvider.Factories;
using LoggingProvider.Models;
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

    public async Task<IEnumerable<string?>> GetAllSessionIdsAsync()
    {
        return await _context.UserEvents
            .Select(ue => ue.SessionId)
            .Distinct()
            .ToListAsync();
    }

    public async Task<IEnumerable<UserEventResponse>> GetUserEventsBySessionIdAsync(string sessionId)
    {
        var userEvents = await _context.UserEvents
            .Where(ue => ue.SessionId == sessionId)
            .OrderBy(ue => ue.EventTimeStamp)
            .ToListAsync();

        var userEventResponses = userEvents.Select(userEvent => EventResponseFactory.Create(userEvent));

        return userEventResponses;
    }

    public async Task<int> GetUserEventsCountAsync()
    {
        var cacheKey = $"getUserEventsCount";

        if (!_cache.TryGetValue(cacheKey, out int cachedCount))
        {
            cachedCount = await _context.UserEvents.CountAsync();

            _cache.Set(cacheKey, cachedCount, TimeSpan.FromMinutes(10));
        }

        return cachedCount;
    }

    public async Task<IEnumerable<UserEventStatsResponse>> GetUserEventsGroupedByHour()
    {
        var startOfDay = DateTime.Now.Date;
        var endOfDay = startOfDay.AddDays(1);

        var groupedData = await _context.UserEvents
            .Where(e => e.EventTimeStamp >= startOfDay && e.EventTimeStamp < endOfDay)
            .GroupBy(e => new
            {
                e.EventTimeStamp.Year,
                e.EventTimeStamp.Month,
                e.EventTimeStamp.Day,
                e.EventTimeStamp.Hour,
            })
            .Select(g => new
            {
                Year = g.Key.Year,
                Month = g.Key.Month,
                Day = g.Key.Day,
                Hour = g.Key.Hour,
                EventCount = g.Count()
            })
            .ToListAsync();

        return groupedData.Select(g => 
        {
            var utcDateTime = new DateTime(g.Year, g.Month, g.Day, g.Hour, 0, 0, DateTimeKind.Utc);
            var localDateTime = utcDateTime.ToLocalTime();

            return new UserEventStatsResponse
            {
                HourlyBucket = localDateTime,
                EventCount = g.EventCount
            };

        }).OrderBy(es => es.HourlyBucket).ToList();
             
    }

    public async Task<IEnumerable<EventTypeStatsResponse>> GetEventTypeDistribution()
    {
        var eventTypeStats = await _context.UserEvents
            .GroupBy(e => e.EventType)
            .Select(g => new EventTypeStatsResponse
            {
                EventType = g.Key.ToString(),
                Count = g.Count()
            })
            .ToListAsync();

            return eventTypeStats;
    }
}
