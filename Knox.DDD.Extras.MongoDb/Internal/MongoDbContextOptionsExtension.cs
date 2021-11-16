using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Abstractions.Persistency.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbContextOptionsExtension : IDbContextOptionsExtension
{
    private readonly string _connectionString;
    private readonly string _databaseName;

    public MongoDbContextOptionsExtension(string connectionString,
        string databaseName)
    {
        _connectionString = connectionString;
        _databaseName = databaseName;
    }

    public void ApplyServices(IServiceCollection services)
    {
        services.AddScoped<IRepositoryFactory, MongoDbRepositoryFactory>();
    }
}