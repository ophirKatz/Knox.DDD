using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbContextSessionFinalizer : IDbContextFinalizer
{
    public Task<bool> FinalizeAsync(IDbContext context)
    {
        MongoDbContextSessionInitializer.ClientSessionHandle!.Dispose();
        return Task.FromResult(true);
    }
}