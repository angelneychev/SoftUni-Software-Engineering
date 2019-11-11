namespace MyCoolCarSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class CarPurchaseConfiguration : IEntityTypeConfiguration<CarPurchase>
    {
        public void Configure(EntityTypeBuilder<CarPurchase> purchase)
        {
            purchase
                .HasKey(p => new { p.CustomerId, p.CarId });
            purchase
                .HasOne(p => p.Customer)
                .WithMany(c => c.Puschases)
                .HasForeignKey(fk => fk.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            purchase
                .HasOne(p => p.Car)
                .WithMany(c => c.Owners)
                .HasForeignKey(fk => fk.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}