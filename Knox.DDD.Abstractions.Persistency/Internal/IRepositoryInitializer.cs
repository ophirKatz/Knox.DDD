namespace Knox.DDD.Abstractions.Persistency.Internal;

public interface IRepositoryInitializer
{
    void InitializeRepositories(IDbContext context);
}