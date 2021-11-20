namespace Knox.DDD.Abstractions.Persistency.Internal;

public interface IDbContextInitializer
{
    void Initialize(IDbContext context, IModel model);
}