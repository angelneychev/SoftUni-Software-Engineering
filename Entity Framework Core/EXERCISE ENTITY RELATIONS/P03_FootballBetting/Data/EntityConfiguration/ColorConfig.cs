namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder
                .HasKey(x => x.ColorId);
            builder
                .Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);
        }
    }
}
