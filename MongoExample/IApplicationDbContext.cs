using Knox.DDD.Abstractions.Interfaces;

namespace MongoExample;

internal interface IApplicationDbContext : IDbContext
{
    IRepository<Product, ProductId> Products { get; }
}