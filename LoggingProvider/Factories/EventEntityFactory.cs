using LoggingProvider.Entities;
using LoggingProvider.Enums;
using LoggingProvider.Models;

namespace LoggingProvider.Factories
{
    public static class EventEntityFactory
    {
        public static UserEventEntity Create(UserEventRequest request)
        {
            return new UserEventEntity
            {
                EventName = request.EventName ?? "",
                EventTimeStamp = DateTime.UtcNow,
                EventType = (EventType)Enum.Parse(typeof(EventType), request.EventType),
                PageUrl = request.PageUrl ?? "",
                SessionId = request.SessionId ?? "",
                UserId = request.UserId ?? ""
            };
        }
        public static AdminEventEntity Create(AdminEventRequest request)
        {
            return new AdminEventEntity
            {
                EventName = request.EventName ?? "",
                EventTimeStamp = DateTime.UtcNow,
                EventType = (EventType)Enum.Parse(typeof(EventType), request.EventType),
                PageUrl = request.PageUrl ?? "",
                AdminId = request.AdminId ?? ""
            };
        }
    }
}