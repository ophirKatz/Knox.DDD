using Knox.DDD.Abstractions;
using Knox.DDD.Abstractions.Persistency;
using MongoDB.Driver;

namespace Knox.DDD.Extras.MongoDb;

public class MongoDbRepository<T, TId> : IRepository<T, TId> where T : AggregateRootBase<TId>
{
    public MongoDbRepository(IMongoCollection<T> collection)
    {
        _collection = collection;
    }

    public void Add(T item, CancellationToken cancellationToken = default)
    {
        _collection.InsertOne(item, new InsertOneOptions(), cancellationToken);
    }

    public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    private readonly IMongoCollection<T> _collection;
}