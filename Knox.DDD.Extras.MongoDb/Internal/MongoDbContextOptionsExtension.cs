﻿using Knox.DDD.Abstractions.Persistency.Internal;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Knox.DDD.Extras.MongoDb.Internal;

public class MongoDbContextOptionsExtension : IDbContextOptionsExtension
{
    private readonly string _connectionString;
    private readonly string _databaseName;

    public MongoDbContextOptionsExtension(string connectionString,
        string databaseName)
    {
        _connectionString = connectionString;
        _databaseName = databaseName;
    }

    public void ApplyServices(IServiceCollection services)
    {
        IMongoClient mongoClient = new MongoClient(_connectionString);
        IMongoDatabase mongoDatabase = mongoClient.GetDatabase(_databaseName);
        services.AddSingleton(mongoClient);
        services.AddSingleton(mongoDatabase);
        services.AddScoped<IRepositoryFactory, MongoDbRepositoryFactory>();
        services.AddScoped<IDbContextInitializer, MongoDbContextTransactionInitializer>();
        services.AddScoped<IDbContextFinalizer, MongoDbContextTransactionFinalizer>();
    }
}