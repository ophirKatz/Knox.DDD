using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb.Internal;

namespace Knox.DDD.Extras.MongoDb;

public static class ServiceCollectionExtensions
{
    public static DbContextOptionsBuilder UseMongoDb(this DbContextOptionsBuilder builder,
        string connectionString,
        string databaseName)
    {
        return builder.AddExtension(new MongoDbContextOptionsExtension(connectionString, databaseName));
    }
}