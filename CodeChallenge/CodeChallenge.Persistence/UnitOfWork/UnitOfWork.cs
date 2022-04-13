using CodeChallenge.Application.Interfaces.Repositories;
using CodeChallenge.Application.Interfaces.UnitOfWork;
using System;

namespace CodeChallenge.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CodeChallengeDbContext _dbContext;
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public UnitOfWork(CodeChallengeDbContext dbContext, IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            _dbContext = dbContext;

            _permissionRepository = permissionRepository;
            _permissionTypeRepository = permissionTypeRepository;
        }

        public IPermissionRepository Permissions => _permissionRepository;

        public IPermissionTypeRepository PermissionTypes => _permissionTypeRepository;

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
    }
}
