namespace Knox.DDD.Abstractions.Persistency.Internal;

public interface IDbContextFinalizer
{
    Task<bool> FinalizeAsync(IDbContext context);
}