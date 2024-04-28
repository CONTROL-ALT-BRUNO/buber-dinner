using BuberDinner.Domain.Base;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host(HostId id) : AggregateRoot<HostId>(id)
{
    public string? FirstName { get; }
    public string? LastName { get; }
    public string? ProfileImage { get; }
    public AverageRating? AverageRating { get; }
    public Guid UserId { get; }
}