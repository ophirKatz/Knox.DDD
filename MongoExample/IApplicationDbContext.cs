using Knox.DDD.Abstractions.Persistency;

namespace MongoExample;

internal interface IApplicationDbContext : IDbContext
{
    IRepository<Product, ProductId> Products { get; }
}