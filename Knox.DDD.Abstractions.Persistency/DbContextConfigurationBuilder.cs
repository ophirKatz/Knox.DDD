namespace Knox.DDD.Abstractions.Persistency;

public class DbContextConfigurationBuilder
{
    private readonly List<IRepositoryOptions> _repositoryOptions;

    public DbContextConfigurationBuilder()
    {
        _repositoryOptions = new List<IRepositoryOptions>();
    }

    public DbContextConfigurationBuilder SetRepositoryOptions(IRepositoryOptions options)
    {
        _repositoryOptions.Add(options);
        return this;
    }

    public DbContextConfiguration Build()
    {
        return new DbContextConfiguration(_repositoryOptions);
    }
}