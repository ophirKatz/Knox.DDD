namespace Knox.DDD.Abstractions.Persistency;

public interface IRepositoryFactory
{
    object? Create(Type entityType, Type entityIdType, IRepositoryOptions options);
}