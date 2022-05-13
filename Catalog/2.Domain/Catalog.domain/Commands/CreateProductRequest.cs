namespace Catalog.domain.Commands
{
    public class CreateProductRequest
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Category { get; set; }
    }
}