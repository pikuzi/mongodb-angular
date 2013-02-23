using System;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace Data.Extensions
{
    public static class MongoCollectionExtensions
    {
        public static T Get<T>(this MongoCollection<T> collection, Guid id)
        {
            var query = Query.EQ("_id", id);
            return collection.FindOne(query);
        }

        public static void Delete<T>(this MongoCollection<T> collection, Guid id)
        {
            var query = Query.EQ("_id", id);
            collection.Remove(query);
        }
    }
}