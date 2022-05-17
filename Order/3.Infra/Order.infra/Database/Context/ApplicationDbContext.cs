using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Order.domain.Entities;
using Order.infra.Database.Config;
using Order.infra.Interfaces;

namespace Order.infra.Database.Context
{
    public class ApplicationDbContext : IOrderContext
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(MongoDbConfig configuration)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase(configuration.Database);
            Orders = _database.GetCollection<Requirement>("Orders");
        }
        public IMongoCollection<Requirement> Orders { get; }
    }
}