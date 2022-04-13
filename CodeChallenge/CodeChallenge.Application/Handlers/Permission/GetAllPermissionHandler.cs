using CodeChallenge.Application.Interfaces.Mapping;
using CodeChallenge.Application.Interfaces.Mediator.Query;
using CodeChallenge.Application.Interfaces.UnitOfWork;
using CodeChallenge.Application.Queries.Permission;
using CodeChallenge.Domain.DTO.Permission;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Application.Handlers.Permission
{
    public class GetAllPermissionHandler : IQueryHandler<GetPermissionQuery, IList<PermissionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapping _mapping;

        public GetAllPermissionHandler(IUnitOfWork unitOfWork, IMapping mapping)
        {
            _unitOfWork = unitOfWork;
            _mapping = mapping;
        }

        public IList<PermissionDto> Handle(GetPermissionQuery query)
        {
            IList<Domain.Entities.Permission> permissions = _unitOfWork.Permissions.GetAll(x => x.Include(permission => permission.Type), x => x.OrderBy(permission => permission.PermissionDate));

            return _mapping.Map<IList<PermissionDto>>(permissions);
        }
    }
}
