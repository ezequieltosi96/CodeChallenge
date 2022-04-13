using CodeChallenge.Domain.Entities;
using CodeChallenge.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Persistence.Configurations
{
    public class PermissionConfiguration : BaseConfiguration<Permission>
    {
        public PermissionConfiguration() : base(@"Permissions")
        {
        }

        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.EmployeeForename).HasMaxLength(100).IsRequired();
            builder.Property(p => p.EmployeeSurname).HasMaxLength(100).IsRequired();
            builder.Property(p => p.PermissionDate).IsRequired();

            builder.HasOne(p => p.Type).WithMany().HasForeignKey(p => p.PermissionType);
        }
    }
}
