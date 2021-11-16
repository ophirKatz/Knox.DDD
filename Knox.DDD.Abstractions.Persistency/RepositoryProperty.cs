namespace Knox.DDD.Abstractions.Persistency;

public delegate void PropertySetter(object? obj, object? value);

public readonly struct RepositoryProperty
{
    public RepositoryProperty(string name,
        Type type,
        Type entityType,
        Type entityIdType,
        PropertySetter? setter)
    {
        Name = name;
        Type = type;
        EntityType = entityType;
        EntityIdType = entityIdType;
        Setter = setter;
    }

    public string Name { get; }
    public Type Type { get; }
    public Type EntityType { get; }
    public Type EntityIdType { get; }
    public PropertySetter? Setter { get; }
}