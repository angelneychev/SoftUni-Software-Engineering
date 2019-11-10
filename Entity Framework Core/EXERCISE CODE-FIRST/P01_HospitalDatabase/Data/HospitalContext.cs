using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
            
        }

        public HospitalContext(DbContextOptions options)
        {
            
        }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnetionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 
            modelBuilder.Entity<Patient>(entity =>
            {
                entity
                    .HasKey(k => k.PatientId);
                entity
                    .Property(p => p.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode();
                entity
                    .Property(p => p.LastName)
                    .HasMaxLength(50)
                    .IsUnicode();
                entity
                    .Property(p => p.Address)
                    .HasMaxLength(250)
                    .IsUnicode();
                entity
                    .Property(p => p.Email)
                    .HasMaxLength(80)
                    .IsUnicode();
                entity
                    .Property(p => p.HasInsurance);

                entity
                    .HasMany(p => p.Prescriptions)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(fk => fk.PatientId);
                entity
                    .HasMany(v => v.Visitations)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(fk => fk.PatientId);
                entity
                    .HasMany(d => d.Diagnoses)
                    .WithOne(p => p.Patient)
                    .HasForeignKey(fk => fk.PatientId);

            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity
                    .HasKey(k => k.VisitationId);
                //entity
                //    .Property(v => v.Date)
                //    .HasColumnType("DATETIME()");
                entity
                    .Property(v => v.Comments)
                    .HasMaxLength(250)
                    .IsUnicode();
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity
                    .HasKey(k => k.DiagnoseId);
                entity
                    .Property(d => d.Comments)
                    .HasMaxLength(250)
                    .IsUnicode();
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity
                    .HasKey(k => k.MedicamentId);
                entity
                    .Property(m => m.Name)
                    .HasMaxLength(50)
                    .IsUnicode();
                entity
                    .HasMany(p => p.Prescriptions)
                    .WithOne(m => m.Medicament)
                    .HasForeignKey(fk => fk.MedicamentId);
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity
                    .HasKey(k => new { k.MedicamentId, k.PatientId });
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity
                    .HasKey(k => k.DoctorId);
                entity
                    .Property(d => d.Name)
                    .HasMaxLength(100)
                    .IsUnicode();
                entity
                    .Property(d => d.Specialty)
                    .IsUnicode();
                entity
                    .HasMany(v => v.Visitations)
                    .WithOne(d => d.Doctor)
                    .HasForeignKey(fk => fk.DoctorId);
            });
        }
    }
}
