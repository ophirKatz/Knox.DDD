using Knox.DDD.Abstractions.Interfaces;

namespace MongoExample
{
    internal interface IProductRepository : IRepository<Product, ProductId>
    {
    }
}