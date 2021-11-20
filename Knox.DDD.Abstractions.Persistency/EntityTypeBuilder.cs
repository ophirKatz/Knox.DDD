using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public abstract class EntityTypeBuilder
{
    protected EntityType _entityType;

    public IEntityType EntityType => _entityType;

    public EntityTypeBuilder()
    {
        _entityType = new EntityType();
    }
}

public class EntityTypeBuilder<T, TId> : EntityTypeBuilder
{
    public EntityTypeBuilder<T, TId> SetOptions(IRepositoryOptions options)
    {
        _entityType = _entityType.SetOptions(options);
        return this;
    }
}