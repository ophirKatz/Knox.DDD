using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbContextTransactionFinalizer : IDbContextFinalizer
{
    public async Task<bool> FinalizeAsync(IDbContext context)
    {
        // TODO : Pass CancellationToken
        await MongoDbContextTransactionInitializer.ClientSessionHandle!.CommitTransactionAsync();
        return true;
    }
}