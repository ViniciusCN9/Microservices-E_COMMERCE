using Order.domain.Entities;

namespace Order.domain.Commands
{
    public class AddProductRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}