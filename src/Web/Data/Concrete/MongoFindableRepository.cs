using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using Web.Data.Extensions;
using Web.Data.Interface;
using Web.Domain;

namespace Web.Data.Concrete
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
            return _collection.Get(id);
        }
    }
}