namespace Knox.DDD.Abstractions.Persistency.Internal;

public class EntityType : IEntityType
{
    private readonly IRepositoryOptions? _options;

    public EntityType()
    {
    }

    private EntityType(IRepositoryOptions options)
    {
        _options = options;
    }

    public IRepositoryOptions GetOptions()
    {
        return _options!;
    }

    internal EntityType SetOptions(IRepositoryOptions options)
    {
        return new EntityType(options);
    }
}