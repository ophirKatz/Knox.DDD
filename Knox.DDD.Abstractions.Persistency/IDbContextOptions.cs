using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public interface IDbContextOptions
{
    IReadOnlyList<IDbContextOptionsExtension> Extensions { get; }
    IReadOnlyDictionary<(Type, Type), IRepositoryOptions> RepositoryOptions { get; }
}