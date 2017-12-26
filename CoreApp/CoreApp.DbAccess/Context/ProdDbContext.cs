using CoreApp.DbAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.DbAccess.Context
{
    public class ProdDbContext : DbContext
    {
        public DbSet<Product> Products{ get; set;}

        public DbSet<Category> Categories { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Unit> Units { get; set; }

        public ProdDbContext(DbContextOptions<ProdDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductCategory>().HasKey(p => new {p.CategoryCode, p.ProductCode});
        }
    }
}
