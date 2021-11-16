using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbContextInitializer : IDbContextInitializer
{
    public MongoDbContextOptions(string connectionString,
        string databaseName)
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
    }

    public string ConnectionString { get; }
    public string DatabaseName { get; }

    public void Initialize(IDbContext context)
    {
        // TODO : Create MongoClient, MongoDatabase with connection string and database name
    }
}