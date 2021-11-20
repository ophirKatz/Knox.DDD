using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public interface IDbContext : IDisposable, IAsyncDisposable
{
    IDbContextOptions Options { get; }
    Task<bool> SaveChangesAsync();
    void OnModelCreating(ModelBuilder builder);
}