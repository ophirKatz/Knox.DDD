using Microsoft.Extensions.DependencyInjection;

namespace Knox.DDD.Abstractions.Persistency.Internal;

public interface IDbContextOptionsExtension
{
    void ApplyServices(IServiceCollection services);
}