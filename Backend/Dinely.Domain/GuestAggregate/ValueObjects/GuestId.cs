using Dinely.Domain.Common.Models;

namespace Dinely.Domain.GuestAggregate.ValueObjects;

public class GuestId : ValueObject
{
    public Guid Value { get; }

    private GuestId(Guid value)
    {
        Value = value;
    }

    private static GuestId CreateUnique()
    {
        return new(Guid.NewGuid());
    }


    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
