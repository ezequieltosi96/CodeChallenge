using CodeChallenge.Application.Interfaces.Repositories;
using CodeChallenge.Domain.Entities;
using CodeChallenge.Persistence.Repositories.Base;
using CodeChallenge.Persistence.UnitOfWork;

namespace CodeChallenge.Persistence.Repositories
{
    public class PermissionTypeRepository : RepositoryBase<PermissionType>, IPermissionTypeRepository
    {
        public PermissionTypeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
