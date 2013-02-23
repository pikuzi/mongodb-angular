using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Domain
{
    public class AggregateRoot
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; protected set; }
    }
}