using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Abstractions.Persistency.Internal;

namespace MongoExample;

internal interface IApplicationDbContext : IDbContext
{
    IRepository<Product, ProductId> Products { get; }
}