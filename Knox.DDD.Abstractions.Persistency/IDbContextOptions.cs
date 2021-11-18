using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public interface IDbContextOptions
{
    IEnumerable<IDbContextOptionsExtension> Extensions { get; }
    internal void Configure(IDbContextConfiguration configuration);
    IRepositoryOptions GetRepositoryOptions(Type entityType, Type entityIdType);
}