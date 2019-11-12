namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasKey(x => x.PlayerId);
            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired(true)
                .IsUnicode(true);
            builder
                .Property(x => x.SquadNumber)
                .IsRequired(true);

            builder
                .HasOne(x => x.Team)
                .WithMany(x => x.Players)
                .HasForeignKey(fk => fk.TeamId);
            builder
                .HasOne(x => x.Position)
                .WithMany(x => x.Players)
                .HasForeignKey(fk => fk.PositionId);
            builder
                .Property(x => x.IsInjured)
                .IsRequired(true);
        }
    }
}
