namespace Knox.DDD.Abstractions.Persistency.Internal;

public class RepositoryInitializer : IRepositoryInitializer
{
    private readonly IRepositoryFinder _repositoryFinder;
    private readonly IRepositoryFactory _repositoryFactory;

    public RepositoryInitializer(IRepositoryFinder repositoryFinder,
        IRepositoryFactory repositoryFactory)
    {
        _repositoryFinder = repositoryFinder;
        _repositoryFactory = repositoryFactory;
    }

    public void InitializeRepositories(IDbContext context)
    {
        foreach (var repositoryProperty in _repositoryFinder.FindRepositories(context.GetType()).Where(p => p.Setter != null))
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
                    $"Repository property {repositoryProperty.Name} on IDbContext type {context.GetType().Name} must have a public set accessor",
                    e
                );
            }
        }
    }
}