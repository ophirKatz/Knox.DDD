using Knox.DDD.Abstractions;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using System.Reflection;
using System.Runtime.Serialization;

namespace Knox.DDD.Extras.MongoDb;

public class AggregateIdGenerator<TId> : IIdGenerator where TId : IdValueBase
{
    private const BindingFlags Flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance;

    public static AggregateIdGenerator<TId> Instance() => new();

    private readonly GuidGenerator _guidGenerator = GuidGenerator.Instance;
    
    public object GenerateId(object container, object document)
    {
        var newGuid = _guidGenerator.GenerateId(container, document);
        var newId = FormatterServices.GetUninitializedObject(typeof(TId)) as TId;
        var t = typeof(TId);
        t.InvokeMember(nameof(IdValueBase.Value), Flags, null, newId, new[] { newGuid });
        return newId!;
    }

    public bool IsEmpty(object id)
    {
        return _guidGenerator.IsEmpty((id as IdValueBase)?.Value);
    }
}