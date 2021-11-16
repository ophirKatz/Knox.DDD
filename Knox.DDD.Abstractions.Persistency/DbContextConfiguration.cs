namespace Knox.DDD.Abstractions.Persistency;

public class DbContextConfiguration
{
    public IReadOnlyList<IRepositoryOptions> RepositoryOptions { get; }

    public DbContextConfiguration(IReadOnlyList<IRepositoryOptions> repositoryOptions)
    {
        RepositoryOptions = repositoryOptions;
    }
}