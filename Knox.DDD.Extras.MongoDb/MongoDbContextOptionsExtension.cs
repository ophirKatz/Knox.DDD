using Knox.DDD.Abstractions.Persistency.Internal;
using Knox.DDD.Extras.MongoDb.Internal;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Knox.DDD.Extras.MongoDb;

public class MongoDbContextOptionsExtension : IDbContextOptionsExtension
{
    public string ConnectionString { get; init; } = string.Empty;
    public string DatabaseName { get; init; } = string.Empty;
    public bool EnableTransaction { get; init; } = false;

    public void ApplyServices(IServiceCollection services)
    {
        //var servers = new List<MongoServerAddress>() { new MongoServerAddress("localhost", 27017) };
        //var credential = MongoCredential.CreateCredential("MongoExample", "root", "password123");
        //var mongoClientSettings = new MongoClientSettings()
        //{
        //    DirectConnection = true,
        //    Credential = credential,
        //    Servers = servers.ToArray(),
        //    ApplicationName = "MongoExample",
        //};
        //IMongoClient mongoClient = new MongoClient(mongoClientSettings);
        IMongoClient mongoClient = new MongoClient(ConnectionString);
        IMongoDatabase mongoDatabase = mongoClient.GetDatabase(DatabaseName);
        services.AddSingleton(mongoClient)
            .AddSingleton(mongoDatabase)
            .AddScoped<IRepositoryFactory, MongoDbRepositoryFactory>()
            .AddScoped<IDbContextInitializer, MongoDbContextSessionInitializer>()
            .AddScoped<IDbContextFinalizer, MongoDbContextSessionFinalizer>();

        if (EnableTransaction)
        {
            services
                .AddScoped<IDbContextInitializer, MongoDbContextTransactionInitializer>()
                .AddScoped<IDbContextFinalizer, MongoDbContextTransactionFinalizer>();
        }
    }
}