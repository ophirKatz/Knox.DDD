using Knox.DDD.Abstractions.Persistency;
using Knox.DDD.Extras.MongoDb;
using MongoExample;

var connectionString = "mongodb://root:password123@localhost:27017";
var databaseName = "Products";

var options = new DbContextOptionsBuilder()
    .UseMongoDb(connectionString, databaseName)
    .Options;

using (var context = new ApplicationDbContext(options))
{
    context.Products.Add(new Product(new ProductId(1)));
}

Console.Read();
