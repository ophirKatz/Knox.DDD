namespace Knox.DDD.Abstractions.Persistency.Internal;

public class RepositoryFinder : IRepositoryFinder
{
    public IReadOnlyList<RepositoryProperty> FindRepositories(Type contextType)
    {
        return contextType.GetProperties()
            .Where(pi =>
            {
                if (!pi.PropertyType.Name.Equals(typeof(IRepository<,>).Name))
                {
                    return false;
                }

                var typeArguments = pi.PropertyType.GetGenericArguments();
                return pi.PropertyType.IsAssignableTo(typeof(IRepository<,>).MakeGenericType(typeArguments));
            })
            .Select(p =>
            {
                var typeArguments = p.PropertyType.GetGenericArguments();
                return new RepositoryProperty(p.Name, p.PropertyType, typeArguments[0], typeArguments[1], p.SetValue);
            }).ToList();
    }
}