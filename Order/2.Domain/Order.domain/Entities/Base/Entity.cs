using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Order.domain.Entities.Base
{
    public abstract class Entity
    {
        public Entity(long id)
        {
            Id = id;
        }

        [BsonId]
        public ObjectId InternalId { get; private set; }
        public long Id { get; private set; }
    }
}