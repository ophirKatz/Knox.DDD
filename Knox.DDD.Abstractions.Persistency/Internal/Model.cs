namespace Knox.DDD.Abstractions.Persistency.Internal;

internal class Model : IModel
{
    private readonly Dictionary<(Type, Type), EntityTypeBuilder> _entityTypeBuilders;

    internal Model()
    {
        _entityTypeBuilders = new Dictionary<(Type, Type), EntityTypeBuilder>();
    }

    private Model(Dictionary<(Type, Type), EntityTypeBuilder> entityTypeBuilders)
    {
        _entityTypeBuilders = new Dictionary<(Type, Type), EntityTypeBuilder>(entityTypeBuilders);
    }

    public IEntityType GetEntityType(Type entityType, Type entityIdType)
    {
        return _entityTypeBuilders[(entityType, entityIdType)]!.EntityType;
    }

    internal Model WithEntity<T, TId>(EntityTypeBuilder<T, TId> builder)
    {
        var newBuilders = _entityTypeBuilders
            .Append(new KeyValuePair<(Type, Type), EntityTypeBuilder>((typeof(T), typeof(TId)), builder))
            .ToDictionary(p => p.Key, p => p.Value);
        return new Model(newBuilders);
    }
}