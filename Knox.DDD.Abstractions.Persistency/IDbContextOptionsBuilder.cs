using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public interface IDbContextOptionsBuilder
{
    IDbContextOptionsBuilder AddExtension(IDbContextOptionsExtension optionsExtension);
    IDbContextOptionsBuilder AddRepositoryOptions<T, TId>(IRepositoryOptions options);
    IDbContextOptionsBuilder AddRepositoryOptions(Func<object> repositorySelector, IRepositoryOptions options);
    IDbContextOptions Build();
}