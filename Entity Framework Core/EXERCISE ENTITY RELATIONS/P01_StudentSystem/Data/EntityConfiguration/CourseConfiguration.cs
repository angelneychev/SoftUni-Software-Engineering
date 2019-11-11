
namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_StudentSystem.Data.Models;

    class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(true);
            builder
                .Property(x => x.Description)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(false);
            builder
                .HasMany(x => x.HomeworkSubmissions)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);
            builder
                .HasMany(x => x.Resources)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);
            builder
                .HasMany(x => x.StudentsEnrolled)
                .WithOne(x => x.Course)
                .HasForeignKey(x => x.CourseId);
            builder
                .Property(x => x.StartDate)
                .IsUnicode(false);
            builder
                .Property(x => x.EndDate)
                .IsUnicode(false);

        }
    }
}
