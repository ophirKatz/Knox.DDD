using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public class DbContextOptionsBuilder : IDbContextOptionsBuilder
{
    private readonly List<IDbContextOptionsExtension> _extensions;
    private readonly Dictionary<(Type, Type), IRepositoryOptions> _repositoryOptions;

    public DbContextOptionsBuilder()
    {
        _extensions = new List<IDbContextOptionsExtension>();
        _repositoryOptions = new Dictionary<(Type, Type), IRepositoryOptions>();
    }

    public IDbContextOptionsBuilder AddExtension(IDbContextOptionsExtension optionsExtension)
    {
        _extensions.Add(optionsExtension);
        return this;
    }

    public IDbContextOptionsBuilder AddRepositoryOptions(IRepositoryOptions options)
    {
        
    }

    public IDbContextOptionsBuilder AddRepositoryOptions<T, TId>(IRepositoryOptions options)
    {
        _repositoryOptions.Add((typeof(T), typeof(TId)), options);
        return this;
    }

    public IDbContextOptionsBuilder AddRepositoryOptions(Func<object> repositorySelector, IRepositoryOptions options)
    {
        var repository = repositorySelector();
        var repositoryType = repository.GetType();
        if (!repositoryType.IsAssignableTo(typeof(IRepository<,>)))
        {
            throw new Exception();
        }
        var typeArguments = repositoryType.GetGenericArguments();
        _repositoryOptions.Add((typeArguments[0], typeArguments[1]), options);
        return this;
    }

    public IDbContextOptions Build()
    {
        return new DbContextOptions(_extensions, _repositoryOptions);
    }
}