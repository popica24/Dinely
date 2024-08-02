using Dinely.Domain.Common.Models;

namespace Dinely.Domain.HostAggregate.ValueObjects;

public class HostId : ValueObject
{
    public string Value { get; set; }

    private HostId(string value)
    {
        Value = value.ToString();
    }

    public static HostId Create(string value)
    {
        return new(value);
    }
    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid().ToString());
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
