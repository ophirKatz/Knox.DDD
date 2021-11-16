using Knox.DDD.Abstractions.Persistency;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbRepositoryOptions : IRepositoryOptions
{
    public MongoDbRepositoryOptions(string collectionName,
        Type entityType)
    {
        CollectionName = collectionName;
        EntityType = entityType;
    }

    public string CollectionName { get; }
    public Type EntityType { get; }
}