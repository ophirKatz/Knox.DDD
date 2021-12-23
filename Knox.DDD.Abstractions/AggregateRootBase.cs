namespace Knox.DDD.Abstractions;

public class AggregateRootBase<TId> : EntityBase<TId> // where TId : IdValueBase
{
    public AggregateRootBase(TId id) : base(id)
    {
    }
}