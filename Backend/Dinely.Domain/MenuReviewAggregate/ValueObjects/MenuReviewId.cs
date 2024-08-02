using Dinely.Domain.Common.Models;

namespace Dinely.Domain.MenuReviewAggregate.ValueObjects
{
    public class MenuReviewId : ValueObject
    {
        public Guid Value { get; }

        private MenuReviewId(Guid value)
        {
            Value = value;
        }
        public static MenuReviewId CreateUnique()
        {
            return new(Guid.NewGuid());
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}