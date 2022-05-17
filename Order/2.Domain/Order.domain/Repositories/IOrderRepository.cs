using MongoDB.Bson;
using Order.domain.Entities;

namespace Order.domain.Repositories
{
    public interface IOrderRepository
    {
        Requirement GetOrder(int id);
        void CreateOrder(Requirement requirement);
        long GetNextId();
    }
}