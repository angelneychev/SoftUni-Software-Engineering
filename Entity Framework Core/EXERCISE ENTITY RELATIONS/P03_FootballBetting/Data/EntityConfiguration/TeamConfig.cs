
namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder
                .HasKey(x => x.TeamId);
            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);
            builder
                .Property(x => x.LogoUrl)
                .HasMaxLength(250)
                .IsRequired(false)
                .IsUnicode(false);
            builder
                .Property(x => x.Initials)
                .HasMaxLength(3)
                .IsRequired(true)
                .IsUnicode(true);
            builder
                .Property(x => x.Budget)
                .IsRequired(true);
            builder
                .HasOne(x => x.PrimaryKitColor)
                .WithMany(x => x.PrimaryKitTeams)
                .HasForeignKey(fk => fk.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.SecondaryKitColor)
                .WithMany(x => x.SecondaryKitTeams)
                .HasForeignKey(fk => fk.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.Town)
                .WithMany(x => x.Teams)
                .HasForeignKey(fk => fk.TeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
