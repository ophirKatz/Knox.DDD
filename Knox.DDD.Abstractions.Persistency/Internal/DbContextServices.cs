namespace Knox.DDD.Abstractions.Persistency.Internal;

internal class DbContextServices : IDbContextServices
{
    private IModel? _model;
    private IDbContext? _currentContext;

    public void Initialize(IDbContext context)
    {
        _currentContext = context;
    }

    public virtual IModel Model => _model ??= CreateModel();

    private IModel CreateModel()
    {
        var modelBuilder = new ModelBuilder();
        _currentContext?.OnModelCreating(modelBuilder);
        return modelBuilder.Model;
    }
}