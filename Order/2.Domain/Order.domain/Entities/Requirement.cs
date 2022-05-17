using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using Order.domain.Entities.Base;

namespace Order.domain.Entities
{
    public class Requirement : Entity
    {
        public Requirement(string username, long id) : base(id)
        {
            Username = username;
            TotalValue = 0m;
            Products = new List<Product>();
            ExpeditionDate = DateTime.Now;
        }

        public string Username { get; private set; }
        public decimal TotalValue { get; private set; }
        public List<Product> Products { get; private set; }
        public DateTime ExpeditionDate { get; private set; }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            TotalValue += product.Price;
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
            TotalValue -= product.Price;
        }

        public bool VerifyExists(int id)
        {
            var product = Products.FirstOrDefault(e => e.Id == id);
            if (product is null)
                return false;
            return true;
        }
    }
}