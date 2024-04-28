using BuberDinner.Domain.Base;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu;

public sealed class Menu(MenuId id) : AggregateRoot<MenuId>(id)
{
    private readonly List<MenuSection> sections = new List<MenuSection>();
    private readonly List<DinnerId> dinnerIds = new List<DinnerId>();
    private readonly List<MenuReviewId> menuReviewIds = new List<MenuReviewId>();
    public string? Name {get;}
    public string? Description {get;}
    public float AverageRating {get;}
    public IReadOnlyList<MenuSection> Sections => sections.ToList().AsReadOnly();
    public HostId? HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => dinnerIds.ToList().AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReviewIds.ToList().AsReadOnly();
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
}