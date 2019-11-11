using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);
            builder
                .Property(x => x.Url)
                .IsUnicode(false)
                .IsRequired(true);
        }
    }
}
