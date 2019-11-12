namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasKey(x => x.GameId);
            builder
                .Property(x => x.HomeTeamGoals)
                .IsRequired(true);
            builder
                .Property(x => x.AwayTeamGoals)
                .IsRequired(true);
            builder
                .Property(x => x.DateTime)
                .IsRequired(true);
            builder
                .Property(x => x.HomeTeamBetRate)
                .IsRequired(true);
            builder
                .Property(x => x.AwayTeamBetRate)
                .IsRequired(true);
            builder
                .Property(x => x.Result)
                .HasMaxLength(7)
                .IsRequired(true);

            builder
                .HasOne(x => x.HomeTeam)
                .WithMany(x => x.HomeGames)
                .HasForeignKey(x => x.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayGames)
                .HasForeignKey(x => x.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
