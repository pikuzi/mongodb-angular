using Data.Extensions;
using Data.Interface;
using Domain;
using MongoDB.Driver;

namespace Data.Concrete
{
    public class MongoWritableRepository<T> : IWritableRepository<T> where T : AggregateRoot
    {
        private readonly MongoDatabase _database;
        private readonly MongoCollection<T> _collection;

        public MongoWritableRepository(MongoDatabase database)
        {
            _database = database;
            _collection = _database.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public void Save(T entity)
        {
            _collection.Save(entity);
        }

        public void Delete(T entity)
        {
            _collection.Delete(entity.Id);
        }
    }
}