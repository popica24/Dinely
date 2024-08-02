namespace Dinely.Domain.Common.Models;

public class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
#pragma warning disable CS8618
    protected AggregateRoot()
    {

    }
#pragma warning restore CS8618
    protected AggregateRoot(TId id) : base(id)
    {

    }

}
