namespace MyCoolCarSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> car)
        {
            car
                .HasIndex(c => c.Vin)
                .IsUnique();
            car
                .HasOne(c => c.Model)
                .WithMany(m => m.Cars)
                .HasForeignKey(fk => fk.ModelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
