namespace Knox.DDD.Abstractions.Interfaces
{
    public interface IDbContext : IDisposable
    {
        IRepository<T, TId> GetRepository<T, TId>() where T : AggregateRootBase<TId>;
        Task<bool> SaveChangesAsync();
    }
}