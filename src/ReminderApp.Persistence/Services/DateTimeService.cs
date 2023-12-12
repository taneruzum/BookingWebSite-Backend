using ReminderApp.Application.Abstractions.Services;

namespace ReminderApp.Persistence.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime UtcNow => DateTime.Now;
    }
}
