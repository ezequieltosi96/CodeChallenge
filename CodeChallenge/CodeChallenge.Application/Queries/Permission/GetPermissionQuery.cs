using CodeChallenge.Application.Interfaces.Mediator.Query;
using CodeChallenge.Domain.DTO.Permission;
using System.Collections.Generic;

namespace CodeChallenge.Application.Queries.Permission
{
    public class GetPermissionQuery : IQuery<IList<PermissionDto>>
    {
    }
}
