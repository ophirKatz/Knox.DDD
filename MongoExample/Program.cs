using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb;
using MongoExample;

var connectionString = "mongodb://localhost:27017";
var databaseName = "Products";

var options = new DbContextOptionsBuilder()
    .UseMongoDb(new MongoDbContextOptionsExtension
    {
        ConnectionString = connectionString,
        DatabaseName = databaseName,
        EnableTransaction = false,
    })
    .Options;

using (var context = new ApplicationDbContext(options))
{
    var id = new ProductId(Guid.NewGuid());
    Console.WriteLine($"Created product with id {id.Value}");
    context.Products.Add(new Product(id, "IPhone"));
    // var product = context.Products.GetByIdAsync(id).GetAwaiter().GetResult();
    // Console.WriteLine($"Found product: {product!.Name}");
    context.SaveChangesAsync().Wait();
}

Console.WriteLine("After adding a product");
Task.Delay(3000).Wait();
