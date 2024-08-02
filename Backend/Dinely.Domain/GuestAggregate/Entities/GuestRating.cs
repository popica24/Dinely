using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dinely.Domain.Common.Models;
using Dinely.Domain.DinnerAggregate.ValueObjects;
using Dinely.Domain.GuestAggregate.ValueObjects;
using Dinely.Domain.HostAggregate.ValueObjects;

namespace Dinely.Domain.GuestAggregate.Entities
{
    public class GuestRating : Entity<RatingId>
    {
        public HostId HostId { get; set; }
        public DinnerId DinnerId { get; set; }
        public int Rating { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        private GuestRating(
            RatingId ratingId, HostId hostId, DinnerId dinnerId, int rating, DateTime createdDateTime,
            DateTime updatedDateTime) : base(ratingId)
        {
            HostId = hostId;
            DinnerId = dinnerId;
            Rating = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static GuestRating Create(HostId hostId, DinnerId dinnerId, int rating)
        {
            return new(
                RatingId.CreateUnique(),
                hostId,
                dinnerId,
                rating,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }
    }
}