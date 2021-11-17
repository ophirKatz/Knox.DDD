namespace Knox.DDD.Abstractions.Persistency.Internal;

public interface IDbContext : IDisposable, IAsyncDisposable
{
    IDbContextOptions Options { get; }

    Task<bool> SaveChangesAsync();

    void Configure(DbContextOptionsBuilder builder);
}