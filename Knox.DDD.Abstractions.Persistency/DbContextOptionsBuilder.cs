using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public class DbContextOptionsBuilder
{
    private DbContextOptions _options;

    public DbContextOptionsBuilder()
    {
        _options = new DbContextOptions();
    }

    public IDbContextOptions Options => _options;

    public DbContextOptionsBuilder AddExtension(IDbContextOptionsExtension extension)
    {
        _options = _options.AddExtension(extension);
        return this;
    }

    public DbContextOptionsBuilder AddRepositoryOptions<TContext>(RepositorySelector<TContext> repositorySelector,
        TContext context,
        IRepositoryOptions options)
        where TContext : DbContext
    {
        _options = _options.AddRepositoryOptions(repositorySelector, context, options);
        return this;
    }
}