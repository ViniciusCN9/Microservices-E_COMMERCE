using MongoDB.Bson;
using MongoDB.Driver;
using Order.domain.Entities;
using Order.domain.Repositories;
using Order.infra.Interfaces;

namespace Order.infra.Database.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private IOrderContext _context;

        public OrderRepository(IOrderContext context)
        {
            _context = context;
        }

        public Requirement GetOrder(string username)
        {
            return _context.Orders.Find(e => e.Username == username && e.IsActive == true).FirstOrDefault();

        }

        public void CreateOrder(Requirement requirement)
        {
            _context.Orders.InsertOneAsync(requirement);
        }

        public void UpdateOrder(string username, Requirement requirement)
        {
            _context.Orders.ReplaceOneAsync(e => e.Username == username && e.IsActive == true, requirement);
        }
    }
}