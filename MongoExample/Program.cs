using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb;
using MongoExample;

var connectionString = "mongodb://root:password123@localhost:27017";
var databaseName = "Products";

var options = new DbContextOptionsBuilder()
    .UseMongoDb(new Knox.DDD.Extras.MongoDb.Internal.MongoDbContextOptionsExtension
    {
        ConnectionString = connectionString,
        DatabaseName = databaseName,
        EnableTransaction = false,
    })
    .Options;

using (var context = new ApplicationDbContext(options))
{
    context.Products.Add(new Product(new ProductId(Guid.NewGuid())));
}

Console.WriteLine("After adding a product");
Console.Read();
