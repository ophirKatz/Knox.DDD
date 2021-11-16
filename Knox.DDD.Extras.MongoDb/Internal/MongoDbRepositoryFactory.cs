using Knox.DDD.Abstractions.Persistency;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbRepositoryFactory : IRepositoryFactory
{
    public MongoDbRepositoryFactory()
    {
        
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