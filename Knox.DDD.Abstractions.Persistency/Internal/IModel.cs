namespace Knox.DDD.Abstractions.Persistency.Internal;

public interface IModel
{
    IEntityType GetEntityType(Type entityType, Type entityIdType);
}