namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P03_FootballBetting.Data.Models;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(x => x.UserId);
            builder
                .Property(x => x.Username)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);
            builder
                .Property(x => x.Password)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);
            builder
                .Property(x => x.Email)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);
            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired(true)
                .IsUnicode(true);
            builder
                .Property(x => x.Balance)
                .IsRequired(true);
        }
    }
}
