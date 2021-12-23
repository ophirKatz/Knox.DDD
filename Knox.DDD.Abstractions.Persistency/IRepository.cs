namespace Knox.DDD.Abstractions.Persistency;

public interface IRepository<T, in TId>
    where T : AggregateRootBase<TId>
    //where TId : IdValueBase
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    void Add(T item, CancellationToken cancellationToken = default);
}