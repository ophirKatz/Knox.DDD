using Knox.DDD.Abstractions;

namespace MongoExample
{
    internal class ProductId : ValueBase
    {
        public ProductId(int id)
        {
            Id = id;
        }

        public int Id { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
        }
    }

    internal class Product : AggregateRootBase<ProductId>
    {
        public Product(ProductId id) : base(id)
        {
        }
    }
}