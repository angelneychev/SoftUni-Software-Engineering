﻿namespace SoftJail.Data
{
	using Microsoft.EntityFrameworkCore;
	using Models;

    public class SoftJailDbContext : DbContext
	{
		public SoftJailDbContext()
		{
		}

		public SoftJailDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<Cell> Cells { get; set; }

		public DbSet<Department> Departments { get; set; }

		public DbSet<Mail> Mails { get; set; }

		public DbSet<Officer> Officers { get; set; }

		public DbSet<OfficerPrisoner> OfficerPrisoners { get; set; }

		public DbSet<Prisoner> Prisoners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<OfficerPrisoner>()
				.HasKey(k => new {k.OfficerId, k.PrisonerId});
			//.Equals(DeleteBehavior.Restrict);
			builder.Entity<OfficerPrisoner>()
				.HasOne<Officer>(x=>x.Officer)
				.WithMany(x=>x.OfficerPrisoners)
				.HasForeignKey(x=>x.OfficerId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.Entity<OfficerPrisoner>()
				.HasOne<Prisoner>(x => x.Prisoner)
				.WithMany(x => x.OfficerPrisoners)
				.HasForeignKey(x => x.PrisonerId)
				.OnDelete(DeleteBehavior.Restrict);



        }
	}
}