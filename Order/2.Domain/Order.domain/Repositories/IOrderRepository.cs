using MongoDB.Bson;
using Order.domain.Entities;

namespace Order.domain.Repositories
{
    public interface IOrderRepository
    {
        Requirement GetOrder(int id, string username);
        void CreateOrder(Requirement requirement);
        void UpdateOrder(int id, Requirement requirement);
        bool VerifyOrder(string username);
        long GetNextId();
    }
}