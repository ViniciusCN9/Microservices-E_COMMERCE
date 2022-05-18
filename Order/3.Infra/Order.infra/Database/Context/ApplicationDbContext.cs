using System;
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
            var databaseSettings = configuration.GetSection("DatabaseSettings");

            var client = new MongoClient(databaseSettings["ConnectionString"]);
            var database = client.GetDatabase(databaseSettings["DatabaseName"]);
            Orders = database.GetCollection<Requirement>(databaseSettings["CollectionName"]);
        }
        public IMongoCollection<Requirement> Orders { get; }
    }
}