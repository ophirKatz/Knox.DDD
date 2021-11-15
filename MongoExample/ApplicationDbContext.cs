using Knox.DDD.Abstractions.Interfaces;
using Knox.DDD.Extras.MongoDb;

namespace MongoExample
{
    internal class ApplicationDbContext : MongoDbContext
    {
        public ApplicationDbContext(string connectionString, string databaseName)
            : base(connectionString, databaseName)
        {
        }

        public IRepository<Product, ProductId> Products { get; }
    }
}