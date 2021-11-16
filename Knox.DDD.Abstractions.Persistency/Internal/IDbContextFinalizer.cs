namespace Knox.DDD.Abstractions.Persistency.Internal;

internal interface IDbContextFinalizer
{
    Task<bool> FinalizeAsync(IDbContext context);
}