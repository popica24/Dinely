using Dinely.Domain.Common.Models;
using Dinely.Domain.DinnerAggregate.ValueObjects;
using Dinely.Domain.HostAggregate.ValueObjects;
using Dinely.Domain.MenuAggregate.ValueObjects;
namespace Dinely.Domain.HostAggregate;

public class Host : AggregateRoot<HostId>
{
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    public IReadOnlyList<MenuId> MenuIds => _menuIds.ToList();
    public IReadOnlyList<DinnerId> DinnerId => _dinnerIds.ToList();

    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        List<MenuId> menuIds,
        List<DinnerId> dinnerIds) : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
        _menuIds = menuIds;
        _dinnerIds = dinnerIds;
    }

    public static Host Create(string firstName,
        string lastName,
        DateTime createdDateTime,
        DateTime updatedDateTime,
        List<MenuId>? menuIds,
        List<DinnerId>? dinnerIds)
    {
        return new Host(
            HostId.CreateUnique(),
            firstName,
            lastName,
            createdDateTime,
            updatedDateTime,
            menuIds ?? new(),
            dinnerIds ?? new()
        );
    }
}
