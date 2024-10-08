using Dinely.Domain.Common.Models;

namespace Dinely.Domain.DinnerAggregate.ValueObjects;

public class ReservationId : ValueObject
{
    public Guid Value { get; }
    private ReservationId(Guid value)
    {
        Value = value;
    }

    public static ReservationId CreateUnique()
    {
        return new ReservationId(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
