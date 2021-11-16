using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public class DbContextOptions : IDbContextOptions
{
    public DbContextOptions(IReadOnlyList<IDbContextOptionsExtension> extensions,
        IReadOnlyDictionary<(Type, Type), IRepositoryOptions> repositoryOptions)
    {
        Extensions = extensions;
        RepositoryOptions = repositoryOptions;
    }

    public IReadOnlyList<IDbContextOptionsExtension> Extensions { get; }

    public IReadOnlyDictionary<(Type, Type), IRepositoryOptions> RepositoryOptions { get; }
}