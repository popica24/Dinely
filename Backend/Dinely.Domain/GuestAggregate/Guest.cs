using Dinely.Domain.Bill.ValueObjects;
using Dinely.Domain.Common.Models;
using Dinely.Domain.DinnerAggregate.ValueObjects;
using Dinely.Domain.GuestAggregate.ValueObjects;
using Dinely.Domain.MenuReviewAggregate.ValueObjects;
using Dinely.Domain.UserAggregate.ValueObjects;

namespace Dinely.Domain.GuestAggregate;

public class Guest : AggregateRoot<GuestId>
{
    private readonly List<DinnerId> _upcomingDinnerIds = new();
    private readonly List<DinnerId> _pastDinnerIds = new();
    private readonly List<DinnerId> _pendingDinnerIds = new();
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewIds = new();

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserId UserId { get; set; }

    
    private Guest(GuestId guestId) : base(guestId)
    {

    }
}
