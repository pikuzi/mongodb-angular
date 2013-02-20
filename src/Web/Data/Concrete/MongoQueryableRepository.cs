using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Web.Data.Interface;
using Web.Domain;

namespace Web.Data.Concrete
{
    public class MongoQueryableRepository<T> : IQueryableRepository<T> where T : AggregateRoot
    {
        private readonly MongoDatabase _database;
        private readonly MongoCollection<T> _collection;

        public MongoQueryableRepository(MongoDatabase database) 
        {
            _database = database;
            _collection = _database.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public IQueryable<T> Query()
        {
            return _collection.AsQueryable();
        }
    }
}