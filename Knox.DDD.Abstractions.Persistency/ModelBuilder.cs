using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public class ModelBuilder
{
    private Model _model;

    public ModelBuilder()
    {
        _model = new Model();
    }

    public IModel Model => _model;

    public virtual EntityTypeBuilder<T, TId> Entity<T, TId>()
    {
        var builder = new EntityTypeBuilder<T, TId>();
        _model = _model.WithEntity(builder);
        return builder;
    }
}