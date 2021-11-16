using Knox.DDD.Abstractions.Persistency.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Knox.DDD.Abstractions.Persistency;

public abstract class DbContext : IDbContext
{
    public IDbContextOptions Options { get; }

    protected DbContext(IDbContextOptions options)
    {
        Options = options;

        foreach (var initializer in ServiceScopeCache.Instance.GetOrAdd(Options)
            .ServiceProvider
            .GetRequiredService<IEnumerable<IDbContextInitializer>>())
        {
            initializer.Initialize(this);
        }
    }

    protected DbContext(IDbContextOptionsBuilder builder)
    {
        Configure(builder);
        Options = builder.Build();

        foreach (var initializer in ServiceScopeCache.Instance.GetOrAdd(Options)
            .ServiceProvider
            .GetRequiredService<IEnumerable<IDbContextInitializer>>())
        {
            initializer.Initialize(this);
        }
    }

    public void Dispose()
    {
        DisposeServiceScope();
    }

    public ValueTask DisposeAsync()
    {
        DisposeServiceScope();
        return ValueTask.CompletedTask;
    }

    public async Task<bool> SaveChangesAsync()
    {
        bool result = true;
        foreach (var finalizer in ServiceScopeCache.Instance
            .GetOrAdd(Options)
            .ServiceProvider
            .GetRequiredService<IEnumerable<IDbContextFinalizer>>())
        {
            result = await finalizer.FinalizeAsync(this);
            if (!result)
            {
                break;
            }
        }

        DisposeServiceScope();

        return result;
    }

    public virtual void Configure(IDbContextOptionsBuilder builder)
    {

    }

    private void DisposeServiceScope()
    {
        ServiceScopeCache.Instance.DisposeFor(Options);
    }
}