using Knox.DDD.Abstractions;
using Knox.DDD.Abstractions.Interfaces;
using Knox.DDD.Extras.MongoDb.Interfaces;
using MongoDB.Driver;

namespace Knox.DDD.Extras.MongoDb
{
    public abstract class MongoDbContext : IDbContext
    {
        private readonly string _connectionString;
        private readonly string _databaseName;

        private readonly IClientSessionHandle _session;
        private readonly IMongoActionsAwaiter _actions;
        private readonly IMongoDatabase _database;
        private readonly IMongoClient _client;

        protected MongoDbContext(string connectionString, string databaseName)
        {
            _connectionString = connectionString;
            _databaseName = databaseName;

            _client = new MongoClient(connectionString);

            _database = _client.GetDatabase(databaseName);

            _actions = new MongoActions();

            _session = _client.StartSession();
        }

        public IRepository<T, TId> GetRepository<T, TId>() where T : AggregateRootBase<TId>
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            await _actions.WhenAll();
            await _session.CommitTransactionAsync();

            return true;
        }

        public void Dispose()
        {
            _session.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
