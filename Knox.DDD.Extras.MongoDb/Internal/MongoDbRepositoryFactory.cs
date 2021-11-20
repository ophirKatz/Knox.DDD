using Knox.DDD.Abstractions.Persistency.Internal;
using MongoDB.Driver;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbRepositoryFactory : IRepositoryFactory
{
    private readonly IMongoDatabase _mongoDatabase;

    public MongoDbRepositoryFactory(IMongoDatabase mongoDatabase)
    {
        _mongoDatabase = mongoDatabase;
    }

    public object? Create(Type entityType, Type entityIdType, IRepositoryOptions options)
    {
        if (options is not MongoDbRepositoryOptions mongoRepositoryOptions)
        {
            throw new Exception("Unable to construct a mongo repository, must provide options with a collection name");
        }
           
        var repositoryType = typeof(MongoDbRepository<,>).MakeGenericType(entityType, entityIdType);
        return Activator.CreateInstance(repositoryType, _mongoDatabase, mongoRepositoryOptions.CollectionName);
    }
}