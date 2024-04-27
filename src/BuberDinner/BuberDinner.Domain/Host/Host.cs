using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Host;

public sealed class Host(HostId id) : AggregateRoot<HostId>(id)
{

}