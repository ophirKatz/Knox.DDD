namespace Knox.DDD.Abstractions.Persistency.Internal;

public interface IRepositoryFactory
{
    object? Create(Type entityType, Type entityIdType, IRepositoryOptions options);
}