using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb.Internal;

namespace Knox.DDD.Extras.MongoDb;

public static class MongoDbModelBuilderExtensions
{
    public static EntityTypeBuilder<T, TId> ConfigureCollectionName<T, TId>(this EntityTypeBuilder<T, TId> builder,
        string collectionName)
    {
        var options = new MongoDbRepositoryOptions(collectionName);
        return builder.SetOptions(options);
    }
}