using System.Collections.Generic;
using System.Linq;
using Catalog.domain.Entities;
using Catalog.domain.Repositories;
using Catalog.infra.Database.Context;

namespace Catalog.infra.Database.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            List<Product> products;
            try
            {
                products = _context.Products.ToList();
            }
            catch
            {
                products = null;
            }

            return products;
        }

        public Product GetProduct(int Id)
        {
            Product product;
            try
            {
                product = _context.Products.FirstOrDefault(e => e.Id == Id);
            }
            catch
            {
                product = null;
            }

            return product;
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}