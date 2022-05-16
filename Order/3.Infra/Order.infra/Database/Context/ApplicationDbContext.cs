using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Order.domain.Entities;
using Order.infra.Interfaces;

namespace Order.infra.Database.Context
{
    public class ApplicationDbContext : IOrderContext
    {

        public ApplicationDbContext(IConfiguration configuration)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("order");
            Orders = database.GetCollection<Requirement>("Orders");
        }
        public IMongoCollection<Requirement> Orders { get; }
    }
}