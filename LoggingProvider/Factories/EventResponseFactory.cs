using LoggingProvider.Entities;
using LoggingProvider.Models;

namespace LoggingProvider.Factories;

public static class EventResponseFactory
{
    public static UserEventResponse Create(UserEventEntity entity)
    {
        return new UserEventResponse
        {
            EventName = entity.EventName ?? "",
            EventTimeStamp = entity.EventTimeStamp.ToString("yyyy-MM-dd HH:mm:ss"),
            EventType = entity.EventType.ToString(),
            PageUrl = entity.PageUrl ?? "",
            SessionId = entity.SessionId ?? "",
            UserId = entity.UserId ?? ""
        };
    }
}
