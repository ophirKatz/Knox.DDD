using Microsoft.Extensions.DependencyInjection;

namespace Knox.DDD.Abstractions.Persistency.Internal;

internal class DbContextOptionsCoreExtension : IDbContextOptionsExtension
{
    public void ApplyServices(IServiceCollection services)
    {
        services.AddScoped<IDbContextServices, DbContextServices>();
        services.AddScoped<IDbContextInitializer, DbContextInitializer>();
        services.AddScoped<IRepositoryFinder, RepositoryFinder>();
    }
}