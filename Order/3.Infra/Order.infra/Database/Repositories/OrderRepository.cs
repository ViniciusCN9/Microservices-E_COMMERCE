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

        public Requirement GetOrder(int id)
        {
            return _context.Orders.Find(e => e.Id == id).FirstOrDefault();
        }

        public void CreateOrder(Requirement requirement)
        {
            _context.Orders.InsertOneAsync(requirement);
        }

        public void UpdateOrder(int id, Requirement requirement)
        {
            _context.Orders.ReplaceOneAsync(e => e.Id == id, requirement);
        }

        public long GetNextId()
        {
            var countDocuments = _context.Orders.CountDocuments(new BsonDocument());
            if (countDocuments == 0)
                return 1;
            return countDocuments + 1;
        }
    }
}