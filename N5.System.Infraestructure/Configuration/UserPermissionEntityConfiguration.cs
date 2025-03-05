using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5.System.Domain.Entities;

namespace N5.System.Infraestructure.Configuration;

internal class UserPermissionEntityConfiguration : IEntityTypeConfiguration<UserPermission>
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.ToTable(string.Format("{0}", nameof(UserPermission)));
        builder.Property(c => c.FirstName).HasMaxLength(128).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(256).IsRequired();
        builder.Property(c => c.PermissionTypeId).IsRequired();
        builder.Property(c => c.DatePermission).IsRequired();
    }
}
