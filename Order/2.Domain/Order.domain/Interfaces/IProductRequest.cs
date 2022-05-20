using Order.domain.Entities;

namespace Order.domain.Interfaces
{
    public interface IProductRequest
    {
        Product GetProduct(int id);
    }
}