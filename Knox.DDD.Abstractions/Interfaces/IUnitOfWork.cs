namespace Knox.DDD.Abstractions.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveChanges();
    }
}