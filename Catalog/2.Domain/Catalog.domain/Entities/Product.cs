using Catalog.domain.Entities.Base;
using Catalog.domain.Enums;

namespace Catalog.domain.Entities
{
    public class Product : Entity
    {
        public Product(string description, decimal price, ECategory category)
        {
            Description = description;
            Price = price;
            Category = category;

        }

        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public ECategory Category { get; private set; }
    }
}