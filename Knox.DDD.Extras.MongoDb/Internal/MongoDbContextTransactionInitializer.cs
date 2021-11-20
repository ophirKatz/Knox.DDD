using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Abstractions.Persistency.Internal;
using MongoDB.Driver;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbContextTransactionInitializer : IDbContextInitializer
{
    private readonly IMongoClient _mongoClient;
    internal static IClientSessionHandle? ClientSessionHandle { get; private set; }

    public MongoDbContextTransactionInitializer(IMongoClient mongoClient)
    {
        _mongoClient = mongoClient;
    }

    public void Initialize(IDbContext context, IModel model)
    {
        ClientSessionHandle = _mongoClient.StartSession();
        ClientSessionHandle.StartTransaction();
    }
}