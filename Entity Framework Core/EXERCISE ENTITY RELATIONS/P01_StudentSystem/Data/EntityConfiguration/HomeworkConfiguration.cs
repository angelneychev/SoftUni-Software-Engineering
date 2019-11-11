using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder
                .Property(x => x.Content)
                .IsUnicode(false);
        }
    }
}
