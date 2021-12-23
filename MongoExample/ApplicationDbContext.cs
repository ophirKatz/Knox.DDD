using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb;
using MongoDB.Bson.Serialization;

namespace MongoExample;

internal class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(IDbContextOptions options) : base(options)
    {
    }

    public IRepository<Product, ProductId> Products { get; set; } = null!;

    public override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product, ProductId>()
            .ConfigureCollectionName(nameof(Products))
            .ConfigureBsonAggregate();

        BsonClassMap.RegisterClassMap<Product>(cm =>
        {
            cm.AutoMap();
            cm.MapCreator(p => new Product(p.Id, p.Name));
        });

        BsonClassMap.RegisterClassMap<ProductId>(cm =>
        {
            cm.AutoMap();
            cm.MapCreator(p => new ProductId(p.Value));
        });

        BsonSerializer.RegisterIdGenerator(
            typeof(ProductId),
            AggregateIdGenerator<ProductId>.Instance()
        );
    }
}