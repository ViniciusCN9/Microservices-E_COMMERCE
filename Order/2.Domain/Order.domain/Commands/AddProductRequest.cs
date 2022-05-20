using Order.domain.Entities;

namespace Order.domain.Commands
{
    public class AddProductRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}