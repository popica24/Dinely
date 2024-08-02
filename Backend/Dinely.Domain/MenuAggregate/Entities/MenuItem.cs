using Dinely.Domain.Common.Models;
using Dinely.Domain.MenuAggregate.ValueObjects;

namespace Dinely.Domain.MenuAggregate.Entities;

public class MenuItem : Entity<MenuItemId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private MenuItem()
    {

    }

    private MenuItem(MenuItemId menuItemId, string name, string description) : base(menuItemId)
    {
        Name = name;
        Description = description;
    }

    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
}
