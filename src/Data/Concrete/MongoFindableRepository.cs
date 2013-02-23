using System;
using Data.Extensions;
using Data.Interface;
using Domain;
using MongoDB.Driver;

namespace Data.Concrete
{
    public class MongoFindableRepository<T> : IFindableRepository<T> where T : AggregateRoot
    {
        private readonly MongoDatabase _database;
        private readonly MongoCollection<T> _collection;

        public MongoFindableRepository(MongoDatabase database)
        {
            _database = database;
            _collection = _database.GetCollection<T>(typeof(T).Name.ToLower());
        }

        public T Find(Guid id)
        {
            return MongoCollectionExtensions.Get<T>(_collection, id);
        }
    }
}