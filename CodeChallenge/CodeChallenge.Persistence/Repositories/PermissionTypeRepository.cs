using CodeChallenge.Application.Interfaces.Repositories;
using CodeChallenge.Domain.Entities;
using CodeChallenge.Persistence.Repositories.Base;

namespace CodeChallenge.Persistence.Repositories
{
    public class PermissionTypeRepository : RepositoryBase<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(CodeChallengeDbContext dbContext) : base(dbContext)
        {
        }

    }
}
