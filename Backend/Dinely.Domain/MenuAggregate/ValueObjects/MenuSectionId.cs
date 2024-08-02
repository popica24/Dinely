using Dinely.Domain.Common.Models;

namespace Dinely.Domain.MenuAggregate.ValueObjects;

public class MenuSectionId : ValueObject
{
    public Guid Value { get; }
    private MenuSectionId(Guid value)
    {
        Value = value;
    }

    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    public static MenuSectionId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
