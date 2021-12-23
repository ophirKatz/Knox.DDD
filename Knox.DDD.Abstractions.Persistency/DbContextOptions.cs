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
}