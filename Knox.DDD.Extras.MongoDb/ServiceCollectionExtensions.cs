using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb.Internal;

namespace Knox.DDD.Extras.MongoDb;

public static class ServiceCollectionExtensions
{
    public static DbContextOptionsBuilder UseMongoDb(this DbContextOptionsBuilder builder,
        MongoDbContextOptionsExtension options)
    {
        return builder.AddExtension(options);
    }
}