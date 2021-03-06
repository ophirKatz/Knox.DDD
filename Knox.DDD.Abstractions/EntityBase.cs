// ReSharper disable NonReadonlyMemberInGetHashCode
namespace Knox.DDD.Abstractions;

public abstract class EntityBase<TId>
{
    protected EntityBase(TId id)
    {
        Id = id;

        DomainEvents = new List<DomainEvent>();
    }

    public TId Id { get; set; }
    public List<DomainEvent> DomainEvents { get; }

    public override bool Equals(object? obj)
    {
        if (obj is not EntityBase<TId> other)
            return false;

        if (ReferenceEquals(this, other))
            return true;

        if (Equals(Id, default) || Equals(other.Id, default))
            return false;

        return Id.Equals(other.Id);
    }

    public static bool operator ==(EntityBase<TId>? a, EntityBase<TId>? b)
    {
        if (a is null && b is null)
            return true;

        if (a is null || b is null)
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(EntityBase<TId> a, EntityBase<TId> b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().ToString() + Id).GetHashCode();
    }

    protected void AddEvent(DomainEvent domainEvent)
    {
        DomainEvents.Add(domainEvent);
    }
}