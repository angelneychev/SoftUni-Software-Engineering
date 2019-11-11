namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class TownConfig : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder
                .HasKey(x => x.TownId);
            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);
            builder
                .HasOne(x => x.Country)
                .WithMany(x => x.Towns)
                .HasForeignKey(fk => fk.CountryId);

        }
    }
}
