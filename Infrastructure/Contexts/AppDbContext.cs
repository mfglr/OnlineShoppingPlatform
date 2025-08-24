using Domain.CartAggregate.Entities;
using Domain.CategoryAggregate.Entities;
using Domain.MaintenanceAggregate.Entities;
using Domain.OrderAggregate.Entities;
using Domain.ProductAggregate.Entities;
using Domain.ProductUserLikeAggregate.Entities;
using Domain.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Infrastructure.Contexts
{
    internal class AppDbContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<Product> Products { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Order> Orders { get; private set; }
        public DbSet<Cart> Carts { get; private set; }
        public DbSet<Category> Categories { get; private set; }
        public DbSet<ProductUserLike> ProductUserLikes { get; private set; }
        public DbSet<Maintenance> Maintenances { get; private set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }

    internal class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Data Source=THENQLV;Initial Catalog=OnlineShoppingPlatform;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new AppDbContext(builder.Options);
        }
    }
}
