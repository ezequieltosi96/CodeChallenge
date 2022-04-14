using CodeChallenge.Application.Exceptions;
using CodeChallenge.Application.Interfaces.ElasticSearch;
using CodeChallenge.Application.Interfaces.Mapping;
using CodeChallenge.Application.Interfaces.Repositories;
using CodeChallenge.Application.Interfaces.Services;
using CodeChallenge.Domain.Base;
using CodeChallenge.Domain.DTO.Permission;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Application.Services.Permission
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository;
        private readonly IElasticClient _elasticClient;
        private readonly IMapping _mapping;

        public PermissionService(IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository, IElasticClient elasticClient, IMapping mapping)
        {
            _permissionRepository = permissionRepository;
            _permissionTypeRepository = permissionTypeRepository;
            _elasticClient = elasticClient;
            _mapping = mapping;
        }

        public int Create(int idPermissionType, string employeeForename, string employeSurname)
        {
            Domain.Entities.PermissionType permissionType = _permissionTypeRepository.GetById(idPermissionType);

            ValidateNullEntity(permissionType, nameof(Domain.Entities.PermissionType), idPermissionType);

            Domain.Entities.Permission permission = new Domain.Entities.Permission
            {
                PermissionType = idPermissionType,
                EmployeeForename = employeeForename,
                EmployeeSurname = employeSurname,
                PermissionDate = DateTime.UtcNow
            };

            _permissionRepository.Create(permission);

            _permissionRepository.Commit();

            _elasticClient.IndexDocument(permission);

            return permission.Id;
        }

        public IList<PermissionDto> GetAll()
        {
            IList<Domain.Entities.Permission> permissions = _permissionRepository.GetAll(x => x.Include(permission => permission.Type), x => x.OrderBy(permission => permission.PermissionDate));

            return _mapping.Map<IList<PermissionDto>>(permissions);
        }

        public int Update(int idPermission, int idPermissionType, string employeeForename, string employeSurname)
        {
            Domain.Entities.Permission permission = _permissionRepository.GetById(idPermission);

            ValidateNullEntity(permission, nameof(Domain.Entities.Permission), idPermission);

            Domain.Entities.PermissionType permissionType = _permissionTypeRepository.GetById(idPermissionType);

            ValidateNullEntity(permissionType, nameof(Domain.Entities.PermissionType), idPermissionType);

            permission.PermissionType = idPermissionType;
            permission.EmployeeForename = employeeForename;
            permission.EmployeeSurname = employeSurname;

            _permissionRepository.Update(permission);

            _permissionRepository.Commit();

            _elasticClient.UpdateDocument(permission);

            return permission.Id;
        }

        private void ValidateNullEntity<T>(T entity, string entityName, int idEntity) where T : EntityBase
        {
            if (entity == null)
            {
                throw new NotFoundException(entityName, idEntity);
            }
        }
    }
}
