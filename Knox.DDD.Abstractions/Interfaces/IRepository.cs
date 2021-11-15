namespace Knox.DDD.Abstractions.Interfaces
{
    public interface IRepository<T, TId> where T : AggregateRootBase<TId>
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T item, CancellationToken cancellationToken = default);
    }
}