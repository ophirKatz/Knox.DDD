using Knox.DDD.Abstractions.Persistency.Internal;

namespace MongoExample.Configuration;

public class MongoDbRepositoryConfiguration : IDbContextConfiguration
{
    public void Configure(IDbContext context)
    {
        builder.SetRepositoryMongoCollection(x => x.Products, this, nameof(Products));
    }
}