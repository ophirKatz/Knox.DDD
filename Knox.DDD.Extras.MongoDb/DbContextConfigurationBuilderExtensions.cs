using Knox.DDD.Abstractions;
using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb.Internal;

namespace Knox.DDD.Extras.MongoDb;

public static class DbContextConfigurationBuilderExtensions
{
    public static DbContextOptionsBuilder SetRepositoryMongoCollection<T, TId>(
        this DbContextOptionsBuilder builder,
        Func<IRepository<T, TId>> repositorySelector,
        string? collectionName = null) where T : AggregateRootBase<TId>
    {
        collectionName ??= typeof(T).Name;
        return builder.AddRepositoryOptions(repositorySelector, new MongoDbRepositoryOptions(collectionName));
    }
}