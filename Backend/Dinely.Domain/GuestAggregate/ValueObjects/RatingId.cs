using Dinely.Domain.Common.Models;

namespace Dinely.Domain.GuestAggregate.ValueObjects
{
    public class RatingId : ValueObject
    {
        public Guid Value { get; }

        private RatingId(Guid value)
        {
            Value = value;
        }

        public static RatingId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}