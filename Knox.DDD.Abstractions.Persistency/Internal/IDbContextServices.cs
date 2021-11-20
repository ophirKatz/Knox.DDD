namespace Knox.DDD.Abstractions.Persistency.Internal;

internal interface IDbContextServices
{
    IModel Model { get; }
    void Initialize(IDbContext context);
}