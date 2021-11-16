namespace Knox.DDD.Abstractions;

public class AggregateRootBase<TId> : EntityBase<TId>
{
    public AggregateRootBase(TId id) : base(id)
    {
    }
}