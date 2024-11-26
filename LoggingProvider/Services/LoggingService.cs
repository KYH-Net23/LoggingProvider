using LoggingProvider.Contexts;
using LoggingProvider.Entities;
using LoggingProvider.Factories;
using LoggingProvider.Models;

namespace LoggingProvider.Services
{
    public class LoggingService(LoggingContext context)
    {
        private readonly LoggingContext _context = context;

        public async Task CreateUserEventsAsync(List<UserEventRequest> requests)
        {
            if (requests.Count < 1 || requests == null) return;
            try
            {
                foreach (var userEventRequest in requests)
                {
                    var userEvent = EventEntityFactory.Create(userEventRequest);
                    await _context.UserEvents.AddAsync(userEvent);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task CreateAdminEventAsync(AdminEventRequest request)
        {
            if (request == null) return;
            try
            {
                var adminEvent = EventEntityFactory.Create(request);
                await _context.AdminEvents.AddAsync(adminEvent);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}