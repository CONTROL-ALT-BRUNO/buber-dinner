namespace BuberDinner.Application.Services.DateTime;

public interface IDateTimeProviderService
{
    System.DateTime UtcNow { get; }
}