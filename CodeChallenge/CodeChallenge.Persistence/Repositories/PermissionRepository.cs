using CodeChallenge.Application.Interfaces.Repositories;
using CodeChallenge.Domain.Entities;
using CodeChallenge.Persistence.Repositories.Base;
using CodeChallenge.Persistence.UnitOfWork;

namespace CodeChallenge.Persistence.Repositories
{
    public class PermissionRepository : RepositoryBase<Permission>, IPermissionRepository
    {
        public PermissionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
