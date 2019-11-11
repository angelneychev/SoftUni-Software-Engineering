namespace MyCoolCarSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> make)
        {
            make
                .HasMany(m => m.Models)
                .WithOne(m => m.Make)
                .HasForeignKey(fk => fk.MakeId)
                .OnDelete(DeleteBehavior.Restrict);
            make
                .HasIndex(m => m.Name)
                .IsUnique();
        }
    }
}
