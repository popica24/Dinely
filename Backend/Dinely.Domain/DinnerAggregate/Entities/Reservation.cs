using Dinely.Domain.Bill.ValueObjects;
using Dinely.Domain.Common.Models;
using Dinely.Domain.DinnerAggregate.ValueObjects;
using Dinely.Domain.GuestAggregate.ValueObjects;

namespace Dinely.Domain.DinnerAggregate.Entities;

public class Reservation : Entity<ReservationId>
{
    public int GuestCount { get; set; }
    public GuestId GuestId { get; set; }
    public BillId BillId { get; set; }
    public DateTime? ArrivalDateTime { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime UpdatedDateTime { get; set; }

    private Reservation(
        ReservationId reservationId,
        int guestCount,
        GuestId guestId,
        BillId billId,
        DateTime? arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime) : base(reservationId)
    {
        GuestCount = guestCount;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static Reservation Create(
        ReservationId reservationId,
        int guestCount,
        GuestId guestId,
        BillId billId,
        DateTime? arrivalDateTime)
    {
        return new Reservation(
            ReservationId.CreateUnique(),
            guestCount,
            guestId,
            billId,
            null,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }
}
