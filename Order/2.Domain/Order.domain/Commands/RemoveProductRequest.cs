namespace Order.domain.Commands
{
    public class RemoveProductRequest
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}