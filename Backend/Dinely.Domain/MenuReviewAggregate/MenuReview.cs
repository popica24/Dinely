using Dinely.Domain.Common.Models;
using Dinely.Domain.DinnerAggregate.ValueObjects;
using Dinely.Domain.GuestAggregate.ValueObjects;
using Dinely.Domain.HostAggregate.ValueObjects;
using Dinely.Domain.MenuAggregate.ValueObjects;
using Dinely.Domain.MenuReviewAggregate.ValueObjects;

namespace Dinely.Domain.MenuReviewAggregate
{
    public class MenuReview : AggregateRoot<MenuReviewId>
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public HostId HostId { get; set; }
        public MenuId MenuId { get; set; }
        public GuestId GuestId { get; set; }
        public DinnerId DinnerId { get; set; }
        public DateTime CretedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private MenuReview(
            MenuReviewId menuReviewId,
            int rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId,
            DateTime createdDateTime,
            DateTime updatedDateTime) : base(menuReviewId)
        {
            Rating = rating;
            Comment = comment;
            HostId = hostId;
            MenuId = menuId;
            GuestId = guestId;
            DinnerId = dinnerId;
            CretedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static MenuReview Create(
            int rating,
            string comment,
            HostId hostId,
            MenuId menuId,
            GuestId guestId,
            DinnerId dinnerId)
        {
            return new(
                MenuReviewId.CreateUnique(),
                rating,
                comment,
                hostId,
                menuId,
                guestId,
                dinnerId,
                DateTime.Now,
                DateTime.Now
                );
        }
    }
}