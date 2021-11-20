using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb;

namespace MongoExample;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(IDbContextOptions options) : base(options)
    {
    }

    public IRepository<Product, ProductId> Products { get; } = null!;

    public override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product, ProductId>()
            .ConfigureCollectionName(nameof(Products))
            .ConfigureBsonId();
    }
}