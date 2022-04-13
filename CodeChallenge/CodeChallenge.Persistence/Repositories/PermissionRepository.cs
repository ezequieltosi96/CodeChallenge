using CodeChallenge.Application.Interfaces.Repositories;
using CodeChallenge.Domain.Entities;
using CodeChallenge.Persistence.Repositories.Base;

namespace CodeChallenge.Persistence.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(CodeChallengeDbContext dbContext) : base(dbContext)
        {
        }
    }
}
