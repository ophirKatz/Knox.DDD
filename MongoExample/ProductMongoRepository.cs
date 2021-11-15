using Knox.DDD.Extras.MongoDb;

namespace MongoExample
{
    internal class ProductMongoRepository : MongoRepositoryBase<Product, ProductId>, IProductRepository
    {
    }
}