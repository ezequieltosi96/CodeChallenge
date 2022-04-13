using CodeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.Persistence
{
    public class CodeChallengeDbContext : DbContext
    {
        public CodeChallengeDbContext(DbContextOptions<CodeChallengeDbContext> options) : base(options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CodeChallengeDbContext).Assembly);
        }
    }
}
