using Knox.DDD.Abstractions.Persistency;

namespace Knox.DDD.Extras.MongoDb;

public static class DbContextOptionsBuilderExtensions
{
    public static DbContextOptionsBuilder UseMongoDb(this DbContextOptionsBuilder builder,
        MongoDbContextOptionsExtension options)
    {
        return builder.AddExtension(options);
    }
}