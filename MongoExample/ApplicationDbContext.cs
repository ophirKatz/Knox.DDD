using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb.Internal;

namespace MongoExample;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(IDbContextOptions options) : base(options)
    {
    }

    public IRepository<Product, ProductId> Products { get; } = null!;

    public override void Configure(DbContextOptionsBuilder builder)
    {
        builder.AddRepositoryOptions(x => x.Products, this, new MongoDbRepositoryOptions(nameof(Products)));
    }
}