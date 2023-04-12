using White.Viper.Digit.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using White.Viper.Digit.Domain.Orders;

namespace White.Viper.Digit.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
        : base (options)
        { }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }
}


