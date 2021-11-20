using Knox.DDD.Abstractions;

namespace MongoExample;

internal class ProductId : IdValueBase
{
    public ProductId(Guid id) : base(id)
    {
    }
}

internal class Product : AggregateRootBase<ProductId>
{
    public Product(ProductId id) : base(id)
    {
    }
}