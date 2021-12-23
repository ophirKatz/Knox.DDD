using Knox.DDD.Abstractions.Persistency.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace Knox.DDD.Abstractions.Persistency;

public abstract class DbContext : IDbContext
{
    private IDbContextServices _contextServices = null!;
    private IDbContextServices ContextServices
    {
        get
        {
            if (_contextServices != null)
            {
                return _contextServices;
            }

            var contextServices = ServiceScopeCache.Instance.GetOrAdd(Options)
                     .ServiceProvider
                     .GetRequiredService<IDbContextServices>();

            contextServices.Initialize(this);
            _contextServices = contextServices;
            return _contextServices;
        }
    }

    public IDbContextOptions Options { get; }

    protected DbContext(IDbContextOptions options)
    {
        Options = options;

        var model = ContextServices.Model;

        foreach (var initializer in ServiceScopeCache.Instance.GetOrAdd(Options)
            .ServiceProvider
            .GetServices<IDbContextInitializer>())
        {
            initializer.Initialize(this, model);
        }
    }

    public void Dispose()
    {
        DisposeServiceScope();
        GC.SuppressFinalize(this);
    }

    public ValueTask DisposeAsync()
    {
        DisposeServiceScope();
        return ValueTask.CompletedTask;
    }

    public async Task<bool> SaveChangesAsync()
    {
        // Finalize should be called on dispose.
        // Transaction finalizer should be called on save!
        var result = true;
        foreach (var finalizer in ServiceScopeCache.Instance.GetOrAdd(Options)
            .ServiceProvider
            .GetServices<IDbContextFinalizer>())
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

    public virtual void OnModelCreating(ModelBuilder builder)
    {
    }

    private void DisposeServiceScope()
    {
        ServiceScopeCache.Instance.DisposeFor(Options);
    }
}