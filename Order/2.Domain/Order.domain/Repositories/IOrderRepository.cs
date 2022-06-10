using MongoDB.Bson;
using Order.domain.Entities;

namespace Order.domain.Repositories
{
    public interface IOrderRepository
    {
        Requirement GetOrder(string username);
        void CreateOrder(Requirement requirement);
        void UpdateOrder(string username, Requirement requirement);
    }
}