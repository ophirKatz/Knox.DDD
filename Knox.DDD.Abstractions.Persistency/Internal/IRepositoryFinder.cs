namespace Knox.DDD.Abstractions.Persistency.Internal;

public interface IRepositoryFinder
{
    IReadOnlyList<RepositoryProperty> FindRepositories(Type contextType);
}