using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbContextTransactionInitializer : IDbContextInitializer
{
    public void Initialize(IDbContext context, IModel model)
    {
        MongoDbContextSessionInitializer.ClientSessionHandle!.StartTransaction();
    }
}