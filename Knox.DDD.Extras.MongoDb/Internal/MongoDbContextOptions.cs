﻿using Knox.DDD.Abstractions.Persistency;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbContextOptions : DbContextOptions
{
    public MongoDbContextOptions(string connectionString,
        string databaseName)
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
    }

    public string ConnectionString { get; }
    public string DatabaseName { get; }
}