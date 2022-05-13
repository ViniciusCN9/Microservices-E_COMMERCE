using System.Collections.Generic;
using Catalog.domain.Entities;

namespace Catalog.domain.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProduct(int Id);
        void CreateProduct(Product product);
    }
}