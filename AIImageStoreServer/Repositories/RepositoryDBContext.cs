using AIImageStoreServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AIImageStoreServer.Repositories
{
    public class RepositoryDBContext: DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get;set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Cart> Carts { get; set; }  
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PurchaseHistory> Purchases { get; set; }

        public RepositoryDBContext(DbContextOptions<RepositoryDBContext> options) : base(options)
        {
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            this.Database.EnsureCreated();
        }
        
    }
}
