namespace Knox.DDD.Extras.MongoDb.Interfaces
{
    public interface IEditableMongoActions
    {
        void Add(Func<Task> action);
    }

    internal interface IMongoActionsAwaiter
    {
        Task WhenAll();
    }

    internal interface IMongoActions : IEditableMongoActions, IMongoActionsAwaiter
    {
        
    }
}