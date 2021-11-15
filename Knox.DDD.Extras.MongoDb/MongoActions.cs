using Knox.DDD.Extras.MongoDb.Interfaces;

namespace Knox.DDD.Extras.MongoDb
{
    internal class MongoActions : IMongoActions
    {
        private readonly List<Func<Task>> _commands;

        public MongoActions()
        {
            _commands = new List<Func<Task>>();
        }

        public void Add(Func<Task> action)
        {
            _commands.Add(action);
        }

        public Task WhenAll()
        {
            var actions = _commands.Select(c => c());
            return Task.WhenAll(actions);
        }
    }
}