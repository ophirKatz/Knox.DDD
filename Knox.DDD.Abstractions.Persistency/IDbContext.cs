namespace Knox.DDD.Abstractions.Persistency;

public interface IDbContext : IDisposable, IAsyncDisposable
{
    IDbContextOptions Options { get; }

    Task<bool> SaveChangesAsync();
    Task DeleteChangesAsync();

    void Configure(DbContextConfigurationBuilder builder);
}