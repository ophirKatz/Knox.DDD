using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Abstractions.Persistency.Internal;
using Knox.DDD.Extras.MongoDb.Internal;
using MongoDB.Driver;

namespace Knox.DDD.Extras.MongoDb;

public abstract class MongoDbContext : IDbContext
{
    private readonly IClientSessionHandle _session;
    private readonly IMongoDatabase _database;
    private readonly IMongoClient _client;

    protected MongoDbContext(MongoDbContextOptions options)
    {
        Options = options;

        _client = new MongoClient(options.ConnectionString);

        _database = _client.GetDatabase(options.DatabaseName);

        ((IRepositoryInitializer)ServiceScopeCache.Instance.ServiceProvider
            .GetService(typeof(IRepositoryInitializer))!)
            .InitializeRepositories(this);

        _session = _client.StartSession();
        _session.StartTransaction();
    }

    public IDbContextOptions Options { get; }

    public async Task<bool> SaveChangesAsync()
    {
        await _session.CommitTransactionAsync();

        return true;
    }

    public void Dispose()
    {
        _session.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task DeleteChangesAsync()
    {
        await _session.AbortTransactionAsync();
    }

    public abstract void Configure(DbContextConfigurationBuilder builder);

    public async ValueTask DisposeAsync()
    {
        await _session.AbortTransactionAsync();
    }
}
