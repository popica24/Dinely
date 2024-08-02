using Dinely.Domain.Common.Models;
using Dinely.Domain.DinnerAggregate.Entities;
using Dinely.Domain.DinnerAggregate.ValueObjects;
using Dinely.Domain.HostAggregate.ValueObjects;
using Dinely.Domain.MenuAggregate.ValueObjects;

namespace Dinely.Domain.DinnerAggregate;

public class Dinner : AggregateRoot<DinnerId>
{
    private readonly List<Reservation> _reserevations = new();
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime? StartedDateTime { get; set; }
    public DateTime? EndedDateTime { get; set; }
    public bool IsPublic { get; set; }
    public int MaxGuests { get; set; }
    public Price Price { get; set; }
    public HostId HostId { get; set; }
    public MenuId MenuId { get; set; }
    public Location Location { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    private Dinner(
        DinnerId dinnerId,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime? startedDateTime,
        DateTime? endedDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        Location location,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(dinnerId)
    {
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        StartedDateTime = startedDateTime;
        EndedDateTime = endedDateTime;
        IsPublic = isPublic;
        MaxGuests = maxGuests;
        Price = price;
        HostId = hostId;
        MenuId = menuId;
        Location = location;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Dinner Create(
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        DateTime? startedDateTime,
        DateTime? endedDateTime,
        bool isPublic,
        int maxGuests,
        Price price,
        HostId hostId,
        MenuId menuId,
        Location location
    )
    {
        return new(
            DinnerId.CreateUnique(),
            name,
            description,
            startDateTime,
            endDateTime,
            null,
            null,
            isPublic,
            maxGuests,
            price,
            hostId,
            menuId,
            location,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
