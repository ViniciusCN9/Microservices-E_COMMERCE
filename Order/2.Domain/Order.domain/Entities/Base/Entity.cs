using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Order.domain.Entities.Base
{
    public abstract class Entity
    {
        [BsonId]
        public ObjectId Id { get; private set; }
    }
}