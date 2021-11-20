namespace Knox.DDD.Abstractions;

public class IdValueBase : ValueBase
{
    public IdValueBase(Guid value)
    {
        Value = value;
    }

    public Guid Value { get; protected set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}