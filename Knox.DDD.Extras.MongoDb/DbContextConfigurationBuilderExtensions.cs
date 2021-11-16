using Knox.DDD.Abstractions;
using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb.Internal;

namespace Knox.DDD.Extras.MongoDb;

public static class DbContextConfigurationBuilderExtensions
{
    public static DbContextConfigurationBuilder SetRepositoryMongoCollection<T, TId>(
        this DbContextConfigurationBuilder builder,
        Func<IRepository<T, TId>> repositorySelector,
        string? collectionName = null) where T : AggregateRootBase<TId>
    {
        collectionName ??= typeof(T).Name;
        var repositoryType = repositorySelector().GetType();
        return builder.ConfigureRepository(new MongoDbRepositoryOptions(collectionName, typeof(T), repositoryType));
    }
}