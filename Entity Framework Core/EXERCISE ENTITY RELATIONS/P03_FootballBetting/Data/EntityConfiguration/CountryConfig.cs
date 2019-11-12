﻿namespace P03_FootballBetting.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder
                .HasKey(x => x.CountryId);
            builder
                .Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired(true)
                .IsUnicode(true);
        }
    }
}
