namespace Knox.DDD.Abstractions.Persistency;

public abstract class DbContext : IDbContext
{
    protected DbContext(IDbContextOptions options);

    public abstract void Dispose();

    public abstract ValueTask DisposeAsync();

    public IDbContextOptions Options { get; }

    public Task<bool> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public Task DeleteChangesAsync()
    {
        throw new NotImplementedException();
    }

    public void Configure(DbContextConfigurationBuilder builder)
    {
        throw new NotImplementedException();
    }
}