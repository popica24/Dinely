using Dinely.Domain.Common.Models;
using Dinely.Domain.MenuAggregate.Entities;
using Dinely.Domain.MenuAggregate.ValueObjects;

namespace Dinely.Domain.MenuAggregate.Entities;

public class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    public string Name { get; private set; }
    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.ToList();
    private MenuSection()
    {

    }
    private MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> menuItems) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items = menuItems;
    }

    public static MenuSection Create(string name, string description, List<MenuItem> menuItems)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description, menuItems);
    }
}
