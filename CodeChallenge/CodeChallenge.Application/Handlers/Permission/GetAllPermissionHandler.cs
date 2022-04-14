using CodeChallenge.Application.Interfaces.Mediator.Query;
using CodeChallenge.Application.Interfaces.Services;
using CodeChallenge.Application.Queries.Permission;
using CodeChallenge.Domain.DTO.Permission;
using System.Collections.Generic;

namespace CodeChallenge.Application.Handlers.Permission
{
    public class GetAllPermissionHandler : IQueryHandler<GetPermissionQuery, IList<PermissionDto>>
    {
        private readonly IPermissionService _permissionService;

        public GetAllPermissionHandler(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        public IList<PermissionDto> Handle(GetPermissionQuery query)
        {
            return _permissionService.GetAll();
        }
    }
}
