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
    public string Name { get; set; }

    public Product(ProductId id, string name) : base(id)
    {
        Name = name;
    }
}