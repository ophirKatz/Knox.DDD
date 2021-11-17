using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public interface IDbContextOptions
{
    IEnumerable<IDbContextOptionsExtension> Extensions { get; }
    IRepositoryOptions GetRepositoryOptions(Type entityType, Type entityIdType);
}