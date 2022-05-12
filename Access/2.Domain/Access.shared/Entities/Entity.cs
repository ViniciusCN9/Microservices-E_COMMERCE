using System;

namespace Access.shared.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            id = Guid.NewGuid();
        }

        public Guid id { get; private set; }
    }
}