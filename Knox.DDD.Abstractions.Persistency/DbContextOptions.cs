using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public delegate object RepositorySelector<in TContext>(TContext context) where TContext : DbContext;

public class DbContextOptions : IDbContextOptions
{
    public DbContextOptions()
    {
        Extensions = new List<IDbContextOptionsExtension>();
    }

    private DbContextOptions(IEnumerable<IDbContextOptionsExtension> extensions)
    {
        Extensions = new List<IDbContextOptionsExtension>(extensions);
    }

    public IEnumerable<IDbContextOptionsExtension> Extensions { get; }

    internal DbContextOptions AddExtension(IDbContextOptionsExtension extension)
    {
        var newExtensions = Extensions.Append(extension).ToList();
        return new DbContextOptions(newExtensions);
    }

    //internal DbContextOptions AddRepositoryOptions<TContext>(RepositorySelector<TContext> repositorySelector,
    //    TContext context,
    //    IRepositoryOptions options)
    //    where TContext : DbContext
    //{
    //    var repository = repositorySelector(context);
    //    var repositoryType = repository.GetType();
    //    if (!repositoryType.IsAssignableTo(typeof(IRepository<,>)))
    //    {
    //        throw new Exception();
    //    }
    //    var typeArguments = repositoryType.GetGenericArguments();
    //    var newOptions = RepositoryOptions
    //        .Append(new KeyValuePair<(Type, Type), IRepositoryOptions>((typeArguments[0], typeArguments[1]), options))
    //        .ToDictionary(p => p.Key, p => p.Value);
    //    return new DbContextOptions(Extensions, Configurations, newOptions);
    //}

    //internal DbContextOptions AddRepositoryOptions<T, TId>(IRepositoryOptions options)
    //{
    //    var newOptions = RepositoryOptions
    //        .Append(new KeyValuePair<(Type, Type), IRepositoryOptions>((typeof(T), typeof(TId)), options))
    //        .ToDictionary(p => p.Key, p => p.Value);
    //    return new DbContextOptions(Extensions, Configurations, newOptions);
    //}

    //internal DbContextOptions Configure(IDbContextConfiguration configuration)
    //{
    //    var newConfigurations = Configurations.Append(configuration).ToList();
    //    return new DbContextOptions(Extensions, newConfigurations, RepositoryOptions);
    //}

    //public void AddRepositoryOptions(Type entityType, Type entityIdType, IRepositoryOptions options)
    //{
    //    throw new NotImplementedException();
    //}
}