using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb.Internal;

namespace Knox.DDD.Extras.MongoDb;

public static class DbContextConfigurationBuilderExtensions
{
    public static DbContextOptionsBuilder SetRepositoryMongoCollection<TContext>(this DbContextOptionsBuilder builder,
        RepositorySelector<TContext> repositorySelector,
        TContext context,
        string collectionName) where TContext : DbContext
    {
        return builder.AddRepositoryOptions(repositorySelector, context, new MongoDbRepositoryOptions(collectionName));
    }
}