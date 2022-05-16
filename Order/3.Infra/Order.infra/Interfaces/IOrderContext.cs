using MongoDB.Driver;
using Order.domain.Entities;

namespace Order.infra.Interfaces
{
    public interface IOrderContext
    {
        IMongoCollection<Requirement> Orders { get; }
    }
}