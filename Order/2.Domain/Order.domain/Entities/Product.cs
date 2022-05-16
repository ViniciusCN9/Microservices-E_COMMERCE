using Order.domain.Entities.Base;

namespace Order.domain.Entities
{
    public class Product
    {
        public Product(int id, string description, decimal price)
        {
            Id = id;
            Description = description;
            Price = price;
        }

        public int Id { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
    }
}