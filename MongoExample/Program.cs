using Knox.DDD.Extras.MongoDb;
using MongoExample;

Console.WriteLine("Hello, World!");

var connectionString = "mongodb://root:password123@localhost:27017";
var databaseName = "Products";

using var context = new ApplicationDbContext(connectionString, databaseName);
