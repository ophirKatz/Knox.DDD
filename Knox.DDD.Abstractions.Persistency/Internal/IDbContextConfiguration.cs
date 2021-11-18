namespace Knox.DDD.Abstractions.Persistency.Internal;

public interface IDbContextConfiguration
{
    void Configure(IDbContext context);
}