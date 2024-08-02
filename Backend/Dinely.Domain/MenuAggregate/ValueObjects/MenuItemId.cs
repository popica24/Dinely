using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dinely.Domain.Common.Models;

namespace Dinely.Domain.MenuAggregate.ValueObjects;

public class MenuItemId : ValueObject
{
    public Guid Value { get; }
    private MenuItemId(Guid value)
    {
        Value = value;
    }

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    public static MenuItemId Create(Guid value)
    {
        return new(value);
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
