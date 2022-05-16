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

        public Requirement GetOrder(ObjectId id)
        {
            return _context.Orders.Find(e => e.Id == id).FirstOrDefault();
        }

        public void CreateOrder(Requirement requirement)
        {
            _context.Orders.InsertOne(requirement);
        }

    }
}