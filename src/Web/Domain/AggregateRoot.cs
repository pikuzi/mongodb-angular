using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Web.Domain
{
    public class AggregateRoot
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid Id { get; protected set; }
    }
}