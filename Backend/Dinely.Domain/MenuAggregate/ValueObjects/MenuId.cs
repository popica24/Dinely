using Dinely.Domain.Common.Models;

namespace Dinely.Domain.MenuAggregate.ValueObjects;

public class MenuId : ValueObject
{
    public Guid Value { get; }
    private MenuId(Guid value)
    {
        Value = value;
    }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
