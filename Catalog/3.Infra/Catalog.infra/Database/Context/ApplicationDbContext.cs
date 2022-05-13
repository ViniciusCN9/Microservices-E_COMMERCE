using Catalog.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.infra.Database.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}