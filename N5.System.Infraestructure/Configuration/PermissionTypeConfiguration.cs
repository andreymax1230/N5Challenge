using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5.System.Domain.Entities;

namespace N5.System.Infraestructure.Configuration;

internal  class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
{
    public void Configure(EntityTypeBuilder<PermissionType> builder)
    {
        builder.ToTable(string.Format("{0}", nameof(PermissionType)));
        builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
    }
}