using MongoExample;

var connectionString = "mongodb://root:password123@localhost:27017";
var databaseName = "Products";

using var context = new ApplicationDbContext(connectionString, databaseName);
