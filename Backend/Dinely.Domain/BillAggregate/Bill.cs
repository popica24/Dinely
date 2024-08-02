using Dinely.Domain.Bill.ValueObjects;
using Dinely.Domain.Common.Models;
using Dinely.Domain.DinnerAggregate.ValueObjects;
using Dinely.Domain.GuestAggregate.ValueObjects;
using Dinely.Domain.HostAggregate.ValueObjects;

namespace Dinely.Domain.BillAggregate;

public class Bill : AggregateRoot<BillId>
{
    public DinnerId DinnerId { get; set; }
    public GuestId GuestId { get; set; }
    public HostId HostId { get; set; }
    public Price Price { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    private Bill(
        BillId billId,
        DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Bill Create(DinnerId dinnerId,
        GuestId guestId,
        HostId hostId,
        Price price)
    {
        return new(
            BillId.CreateUnique(),
            dinnerId,
            guestId,
            hostId,
            price,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

}
