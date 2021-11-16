using Knox.DDD.Abstractions.Persistency.Internal;

namespace Knox.DDD.Abstractions.Persistency;

public interface IDbContextOptionsBuilder
{
    IDbContextOptionsBuilder AddExtension(IDbContextOptionsExtension optionsExtension);
    IDbContextOptions Build();
}