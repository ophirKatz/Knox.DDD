using Knox.DDD.Abstractions;
using Knox.DDD.Abstractions.Interfaces;
using Knox.DDD.Extras.MongoDb.Interfaces;
using MongoDB.Driver;

namespace Knox.DDD.Extras.MongoDb
{
    public abstract class MongoRepositoryBase<T, TId> : IRepository<T, TId> where T : AggregateRootBase<TId>
    {
        protected MongoRepositoryBase(IMongoCollection<T> collection, IEditableMongoActions mongoActions)
        {
            Collection = collection;
            MongoActions = mongoActions;
        }

        public IMongoCollection<T> Collection { get; }
        protected IEditableMongoActions MongoActions { get; }

        public void Add(T item, CancellationToken cancellationToken = default)
        {
            MongoActions.Add(() => Task.CompletedTask);
        }

        public Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}