using Knox.DDD.Abstractions.Persistency;
using MongoDB.Driver;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbRepositoryFactory : IRepositoryFactory
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _mongoDatabase;

    public MongoDbRepositoryFactory(IMongoClient mongoClient,
        IMongoDatabase mongoDatabase)
    {
        _mongoClient = mongoClient;
        _mongoDatabase = mongoDatabase;
    }

    public object? Create(Type entityType, Type entityIdType, IRepositoryOptions options)
    {
        if (options is not MongoDbRepositoryOptions mongoRepositoryOptions)
        {
            throw new Exception();
        }
           
        var repositoryType = typeof(MongoDbRepository<,>).MakeGenericType(entityType, entityIdType);
        return Activator.CreateInstance(repositoryType, mongoRepositoryOptions.CollectionName);
    }
}