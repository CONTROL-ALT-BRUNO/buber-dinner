using BuberDinner.Application.Services.DateTime;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProviderService : IDateTimeProviderService
{
    public DateTime UtcNow => DateTime.Now;
}