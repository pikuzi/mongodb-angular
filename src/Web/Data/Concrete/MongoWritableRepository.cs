using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using Pluralize;
using Web.Data.Interface;
using Web.Domain;

namespace Web.Data.Concrete
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
    }
}