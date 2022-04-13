using CodeChallenge.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeChallenge.Persistence.Configurations.Base
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        protected string TableName { get; }

        public BaseConfiguration(string tableName)
        {
            TableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (!string.IsNullOrEmpty(TableName))
            {
                builder.HasKey(e => e.Id);
                builder.ToTable(TableName);
            }
        }
    }
}
