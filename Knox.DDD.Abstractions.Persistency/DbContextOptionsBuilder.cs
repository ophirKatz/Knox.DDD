using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public class DbContextOptionsBuilder
{
    private DbContextOptions _options;

    public DbContextOptionsBuilder()
    {
        _options = new DbContextOptions().AddExtension(new DbContextOptionsCoreExtension());
    }

    public IDbContextOptions Options => _options;

    public DbContextOptionsBuilder AddExtension(IDbContextOptionsExtension extension)
    {
        _options = _options.AddExtension(extension);
        return this;
    }

    //public DbContextOptionsBuilder AddRepositoryOptions<TContext>(RepositorySelector<TContext> repositorySelector,
    //    TContext context,
    //    IRepositoryOptions options)
    //    where TContext : DbContext
    //{
    //    _options = _options.AddRepositoryOptions(repositorySelector, context, options);
    //    return this;
    //}

    //public DbContextOptionsBuilder AddRepositoryOptions<T, TId>(IRepositoryOptions options)
    //{
    //    _options = _options.AddRepositoryOptions<T, TId>(options);
    //    return this;
    //}

    //public DbContextOptionsBuilder Configure<TConfiguration>()
    //    where TConfiguration : IDbContextConfiguration, new()
    //{
    //    _options = _options.Configure(new TConfiguration());
    //    return this;
    //}

    //public DbContextOptionsBuilder Configure(IDbContextConfiguration configuration)
    //{
    //    _options = _options.Configure(configuration);
    //    return this;
    //}
}