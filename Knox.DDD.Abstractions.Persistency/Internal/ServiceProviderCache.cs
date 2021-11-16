namespace Knox.DDD.Abstractions.Persistency.Internal;

public class ServiceProviderCache
{
    public static ServiceProviderCache Instance { get; } = new();

    public IServiceProvider ServiceProvider { get; }
}