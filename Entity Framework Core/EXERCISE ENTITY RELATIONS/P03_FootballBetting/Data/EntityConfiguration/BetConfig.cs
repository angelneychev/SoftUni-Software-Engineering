namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class BetConfig : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder
                .HasKey(x => x.BetId);
            builder
                .Property(x => x.Amount)
                .IsRequired(true);
            builder
                .Property(x => x.Prediction)
                .IsRequired(true);
            builder
                .Property(x => x.DateTime)
                .IsRequired(true);
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Bets)
                .HasForeignKey(fk => fk.UserId);
            builder
                .HasOne(x => x.Game)
                .WithMany(x => x.Bets)
                .HasForeignKey(fk => fk.GameId);
        }
    }
}
