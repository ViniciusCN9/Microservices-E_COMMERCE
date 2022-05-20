using MongoDB.Bson;
using Order.domain.Entities;

namespace Order.domain.Repositories
{
    public interface IOrderRepository
    {
        Requirement GetOrder(int id);
        void CreateOrder(Requirement requirement);
        void UpdateOrder(int id, Requirement requirement);
        long GetNextId();
    }
}