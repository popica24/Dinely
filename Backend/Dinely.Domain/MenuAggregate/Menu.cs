using Dinely.Domain.Common.Models;
using Dinely.Domain.DinnerAggregate.ValueObjects;
using Dinely.Domain.HostAggregate.ValueObjects;
using Dinely.Domain.MenuAggregate.Entities;
using Dinely.Domain.MenuAggregate.Events;
using Dinely.Domain.MenuAggregate.ValueObjects;
using Dinely.Domain.MenuReviewAggregate.ValueObjects;

namespace Dinely.Domain.MenuAggregate;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinnerIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string Name { get; private set; }
    public string Description { get; private set; }
    public HostId HostId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public IReadOnlyList<MenuSection> Sections => _sections.ToList();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.ToList();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.ToList();

    private Menu()
    {

    }

    private Menu(
        MenuId menuId, HostId hostId, string name, string description, DateTime createdDateTime,
        DateTime updatedDateTime, List<MenuSection> sections, List<DinnerId> dinnerIds, List<MenuReviewId> menuReviewIds) : base(menuId)
    {
        HostId = hostId;
        Name = name;
        Description = description;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        _sections = sections;
        _dinnerIds = dinnerIds;
        _menuReviewIds = menuReviewIds;
    }

    public static Menu Create(HostId hostId, string name, string description, List<MenuSection>? sections)
    {
        var menu = new Menu(
            MenuId.CreateUnique(),
            hostId,
            name,
            description,
            DateTime.UtcNow,
            DateTime.UtcNow,
            sections ?? new(),
            new(),
            new()
        );

        menu.AddDomainEvent(new MenuCreated(menu));

        return menu;

    }
}
