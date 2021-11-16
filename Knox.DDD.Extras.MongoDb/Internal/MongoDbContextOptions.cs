using Knox.DDD.Abstractions.Persistency;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbContextOptions : IDbContextOptions
{
    public MongoDbContextOptions(string connectionString,
        string databaseName)
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
    }

    public string ConnectionString { get; }
    public string DatabaseName { get; }
}