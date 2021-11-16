namespace Knox.DDD.Abstractions.Persistency.Internal;

public class DbContextInitializer : IDbContextInitializer
{
    private readonly IRepositoryFinder _repositoryFinder;
    private readonly IRepositoryFactory _repositoryFactory;

    public DbContextInitializer(IRepositoryFinder repositoryFinder,
        IRepositoryFactory repositoryFactory)
    {
        _repositoryFinder = repositoryFinder;
        _repositoryFactory = repositoryFactory;
    }

    public void Initialize(IDbContext context)
    {
        InitializeRepositories(context);
    }

    private void InitializeRepositories(IDbContext context)
    {
        foreach (var repositoryProperty in _repositoryFinder.FindRepositories(context.GetType()))
        {
            var repositoryInstance =
                _repositoryFactory.Create(repositoryProperty.EntityType, repositoryProperty.EntityIdType, null);
            try
            {
                repositoryProperty.Setter!.Invoke(context, repositoryInstance);
            }
            catch (Exception e)
            {
                throw new Exception(
                    $"Repository property {repositoryProperty.Name} on DbContext type {context.GetType().Name} must have a public set accessor",
                    e
                );
            }
        }
    }
}