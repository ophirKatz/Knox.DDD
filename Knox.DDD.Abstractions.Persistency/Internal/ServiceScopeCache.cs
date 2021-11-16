using Microsoft.Extensions.DependencyInjection;
using System.Collections.Concurrent;

namespace Knox.DDD.Abstractions.Persistency.Internal;

public class ServiceScopeCache
{
    private readonly ConcurrentDictionary<IDbContextOptions, IServiceScope> _configurations = new();
    public static ServiceScopeCache Instance { get; } = new();

    public IServiceScope GetOrAdd(IDbContextOptions options)
    {
        if (_configurations.TryGetValue(options, out var scope)) return scope;

        var services = new ServiceCollection();
        foreach (var extension in options.Extensions)
        {
            extension.ApplyServices(services);
        }
        var serviceProvider = services.BuildServiceProvider();

        scope = serviceProvider.CreateScope();
        _configurations.TryAdd(options, scope);
        return scope;
    }

    public void DisposeFor(IDbContextOptions options)
    {
        var exists = _configurations.TryRemove(options, out var scope);
        if (!exists) return;
        scope!.Dispose();
    }
}