namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    class PlayerStatisticConfig : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder
                .HasKey(x => new {x.PlayerId, x.GameId});
            builder
                .Property(x => x.ScoredGoals)
                .IsRequired(true);
            builder
                .Property(x => x.Assists)
                .IsRequired(true);
            builder
                .Property(x => x.MinutesPlayed)
                .IsRequired(true);
            builder
                .HasOne(x => x.Game)
                .WithMany(x => x.PlayerStatistics)
                .HasForeignKey(fk => fk.GameId);
            builder
                .HasOne(x => x.Player)
                .WithMany(x => x.PlayerStatistics)
                .HasForeignKey(fk => fk.PlayerId);

        }
    }
}
