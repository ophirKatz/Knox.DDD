using Knox.DDD.Abstractions;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Reflection;
using System.Runtime.Serialization;

namespace Knox.DDD.Extras.MongoDb;

public class AggregateIdGenerator<TId> : IIdGenerator where TId : IdValueBase
{
    private readonly BindingFlags _flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance;

    public static AggregateIdGenerator<TId> Instance() => new AggregateIdGenerator<TId>();

    public object GenerateId(object container, object document)
    {
        var newGuid = GuidGenerator.Instance.GenerateId(container, document);
        var newId = FormatterServices.GetUninitializedObject(typeof(TId)) as TId;
        Type t = typeof(TId);
        t.InvokeMember(nameof(IdValueBase.Value), _flags, null, newId, new object[] { newGuid });
        return newId!;
    }

    public bool IsEmpty(object id)
    {
        return GuidGenerator.Instance.IsEmpty((id as IdValueBase)?.Value);
    }
}