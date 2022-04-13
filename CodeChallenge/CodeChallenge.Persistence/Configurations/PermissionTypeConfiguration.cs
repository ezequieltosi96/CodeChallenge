using CodeChallenge.Domain.Entities;
using CodeChallenge.Persistence.Configurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Persistence.Configurations
{
    public class PermissionTypeConfiguration : BaseConfiguration<PermissionType>
    {
        public PermissionTypeConfiguration() : base(@"PermissionTypes")
        {
        }

        public override void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Description).HasMaxLength(50).IsRequired();
        }
    }
}
