using CodeChallenge.Domain.DTO.Permission;
using System.Collections.Generic;

namespace CodeChallenge.Application.Interfaces.Services
{
    public interface IPermissionService
    {
        int Create(int idPermissionType, string employeeForename, string employeSurname);

        int Update(int idPermission, int idPermissionType, string employeeForename, string employeSurname);

        IList<PermissionDto> GetAll();
    }
}
