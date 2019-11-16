using System.Reflection;

namespace MyCoolCarSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyCoolCarSystem.Data.Models;
    using MyCoolCarSystem.Data.Configurations;

    public class CarDbContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarPurchase> CarPurchases { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(DateSettings.DefaultConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
           
            //builder.ApplyConfiguration(new MakeConfiguration());

            //builder.ApplyConfiguration(new CarConfiguration());

            //builder.ApplyConfiguration(new CarPurchaseConfiguration());

            //builder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
