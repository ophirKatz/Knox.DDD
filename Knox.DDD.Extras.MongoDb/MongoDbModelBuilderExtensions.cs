using Knox.DDD.Abstractions;
using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb.Internal;
using MongoDB.Bson.Serialization;

namespace Knox.DDD.Extras.MongoDb;

public static class MongoDbModelBuilderExtensions
{
    public static EntityTypeBuilder<T, TId> ConfigureCollectionName<T, TId>(this EntityTypeBuilder<T, TId> builder,
        string collectionName)
    {
        var options = new MongoDbRepositoryOptions(collectionName);
        return builder.SetOptions(options);
    }

    public static EntityTypeBuilder<T, TId> ConfigureBsonId<T, TId>(this EntityTypeBuilder<T, TId> builder)
        where T : AggregateRootBase<TId>
        where TId : IdValueBase
    {
        BsonSerializer.RegisterIdGenerator(
            typeof(TId),
            AggregateIdGenerator<TId>.Instance()
        );

        return builder;
    }
}