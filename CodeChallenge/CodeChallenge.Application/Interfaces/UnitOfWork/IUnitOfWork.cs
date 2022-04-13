using CodeChallenge.Application.Interfaces.Repositories;
using System;

namespace CodeChallenge.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPermissionRepository Permissions { get; } 
        IPermissionTypeRepository PermissionTypes { get; } 

        void Commit();
    }
}
