using ContactManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManagement.Data.Mappings
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(191).HasColumnType("varchar(191)");
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(15).HasColumnType("varchar(191)");
            builder.Property(c => c.Email).IsRequired().HasMaxLength(191).HasColumnType("varchar(191)");

            builder.HasIndex(e => new { e.Phone, e.Email }).IsUnique();

            builder.HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
