using Knox.DDD.Abstractions;
using Knox.DDD.Abstractions.Persistency;
using MongoDB.Driver;

namespace Knox.DDD.Extras.MongoDb;

public class MongoDbRepository<T, TId> : IRepository<T, TId>
    where T : AggregateRootBase<TId>
{
    public MongoDbRepository(IMongoDatabase mongoDatabase,
        string collectionName)
    {
        _collection = mongoDatabase.GetCollection<T>(collectionName);
    }

    public void Add(T item, CancellationToken cancellationToken = default)
    {
        _collection.InsertOne(item, new InsertOneOptions(), cancellationToken);
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await _collection.FindAsync(x => true, cancellationToken: cancellationToken);
        return result.Current;
    }

    public async Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        var result = await _collection.FindAsync(x => Equals(x.Id, id), cancellationToken: cancellationToken);
        return result.Current.First();
    }

    private readonly IMongoCollection<T> _collection;
}