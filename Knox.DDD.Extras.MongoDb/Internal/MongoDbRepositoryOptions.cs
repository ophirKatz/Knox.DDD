using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbRepositoryOptions : IRepositoryOptions
{
    public MongoDbRepositoryOptions(string collectionName)
    {
        CollectionName = collectionName;
    }

    public string CollectionName { get; }
}