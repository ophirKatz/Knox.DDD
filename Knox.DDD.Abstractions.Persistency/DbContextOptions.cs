using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public delegate object RepositorySelector<in TContext>(TContext context) where TContext : DbContext;

public class DbContextOptions : IDbContextOptions
{
    public DbContextOptions()
    {
        Extensions = new List<IDbContextOptionsExtension>();
        RepositoryOptions = new Dictionary<(Type, Type), IRepositoryOptions>();
    }

    private DbContextOptions(IEnumerable<IDbContextOptionsExtension> extensions,
        IReadOnlyDictionary<(Type, Type), IRepositoryOptions> repositoryOptions)
    {
        Extensions = new List<IDbContextOptionsExtension>(extensions);
        RepositoryOptions = new Dictionary<(Type, Type), IRepositoryOptions>(repositoryOptions);
    }

    public IEnumerable<IDbContextOptionsExtension> Extensions { get; }

    void IDbContextOptions.Configure(IDbContextConfiguration configuration)
    {
        throw new NotImplementedException();
    }

    public IRepositoryOptions GetRepositoryOptions(Type entityType, Type entityIdType)
    {
        // TODO : TryGet
        return RepositoryOptions[(entityType, entityIdType)];
    }

    private IReadOnlyDictionary<(Type, Type), IRepositoryOptions> RepositoryOptions { get; }

    internal DbContextOptions AddExtension(IDbContextOptionsExtension extension)
    {
        var newExtensions = Extensions.Append(extension).ToList();
        return new DbContextOptions(newExtensions, RepositoryOptions);
    }

    internal DbContextOptions AddRepositoryOptions<TContext>(RepositorySelector<TContext> repositorySelector,
        TContext context,
        IRepositoryOptions options)
        where TContext : DbContext
    {
        var repository = repositorySelector(context);
        var repositoryType = repository.GetType();
        if (!repositoryType.IsAssignableTo(typeof(IRepository<,>)))
        {
            throw new Exception();
        }
        var typeArguments = repositoryType.GetGenericArguments();
        var newOptions = RepositoryOptions
            .Append(new KeyValuePair<(Type, Type), IRepositoryOptions>((typeArguments[0], typeArguments[1]), options))
            .ToDictionary(p => p.Key, p => p.Value);
        return new DbContextOptions(Extensions, newOptions);
    }
}